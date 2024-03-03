using System.Net;
using Vault;
using Vault.Client;
using Vault.Model;

namespace HashiCorpVaultClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "https://vault.ofaruksahin.com";
            var token = "";
            var configName = "sample_config";
            var projectName = "test";

            VaultConfiguration config = new VaultConfiguration(url);
            VaultClient vaultClient = new VaultClient(config);
            vaultClient.SetToken(token);

            try
            {
                VaultResponse<KvV2ReadResponse> resp = vaultClient.Secrets.KvV2Read(configName,projectName);
                Console.WriteLine(resp.Data.Data);
            }
            catch (VaultApiException e)
            {
                Console.WriteLine("Status code: {0}", e.StatusCode);

                e.Errors.ToList().ForEach(x => Console.WriteLine(x));

                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}