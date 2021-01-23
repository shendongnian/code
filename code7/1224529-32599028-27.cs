    public class EncryptionProvider
    {
        //
        // authentication properties omitted
        public KeyBundle MyKeyBundle;
        public EncryptionProvider() { }
        public async Task GetKeyBundle()
        {
            var keyVaultClient = new KeyVaultClient(GetAccessToken);
            var keyBundleTask = await keyVaultClient
                .GetKeyAsync(KeyVaultUrl, KeyVaultEncryptionKeyName);
            MyKeyBundle = keyBundleTask;
        }
        private async Task<string> GetAccessToken(
            string authority, string resource, string scope)
        {
            TokenCache.DefaultShared.Clear(); // reproduce issue 
            var authContext = new AuthenticationContext(authority, TokenCache.DefaultShared);
            var clientCredential = new ClientCredential(ClientIdWeb, ClientSecretWeb);
            var result = await authContext.AcquireTokenAsync(resource, clientCredential);
            var token = result.AccessToken;
            return token;
        }
    }
