    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Azure.KeyVault;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    
    namespace ConsoleApp2
    {
        class Program
        {
            private static async Task RunSample()
            {
                var keyVaultClient = new KeyVaultClient(GetAccessToken);
    
                // create a key :)
                var keyCreate = await keyVaultClient.CreateKeyAsync(
                    vault: _keyVaultUrl,
                    keyName: _keyVaultEncryptionKeyName,
                    keyType: _keyType,
                    keyAttributes: new KeyAttributes()
                    {
                        Enabled = true,
                        Expires = UnixEpoch.FromUnixTime(int.MaxValue),
                        NotBefore = UnixEpoch.FromUnixTime(0),
                    },
                    tags: new Dictionary<string, string> {
                        { "purpose", "StackOverflow Demo" }
                    });
    
                Console.WriteLine(string.Format(
                    "Created {0} ",
                    keyCreate.KeyIdentifier.Name));
    
                // retrieve the key
                var keyRetrieve = await keyVaultClient.GetKeyAsync(
                    _keyVaultUrl,
                    _keyVaultEncryptionKeyName);
    
                Console.WriteLine(string.Format(
                    "Retrieved {0} ",
                    keyRetrieve.KeyIdentifier.Name));
            }
    
            private static async Task<string> GetAccessToken(
                string authority, string resource, string scope)
            {
                var clientCredential = new ClientCredential(
                    _keyVaultAuthClientId,
                    _keyVaultAuthClientSecret);
    
                var context = new AuthenticationContext(
                    authority,
                    TokenCache.DefaultShared);
    
                var result = await context.AcquireTokenAsync(resource, clientCredential);
    
                _expiresOn = result.ExpiresOn.DateTime;
    
                Console.WriteLine(DateTime.UtcNow.ToShortTimeString());
                Console.WriteLine(_expiresOn.ToShortTimeString());
    
                return result.AccessToken;
            }
    
            private static DateTime _expiresOn;
            private static string
                _keyVaultAuthClientId = "xxxxx-xxx-xxxxx-xxx-xxxxx",
                _keyVaultAuthClientSecret = "xxxxx-xxx-xxxxx-xxx-xxxxx",
                _keyVaultEncryptionKeyName = "MYENCRYPTIONKEY",
                _keyVaultUrl = "https://xxxxx.vault.azure.net/",
                _keyType = "RSA";
    
            static void Main(string[] args)
            {
                var keepGoing = true;
                while (keepGoing)
                {
                    RunSample().GetAwaiter().GetResult();
                    // sleep for five minutes
                    System.Threading.Thread.Sleep(new TimeSpan(0, 5, 0)); 
                    if (DateTime.UtcNow > _expiresOn)
                    {
                        Console.WriteLine("---Expired---");
                        Console.ReadLine();
                    }
                }
            }
        }
    }
