      public static string GetTokenForApplication()
            {
                AuthenticationContext authenticationContext = new AuthenticationContext(Constants.AuthString, false);
                // Config for OAuth client credentials 
                ClientCredential clientCred = new ClientCredential(Constants.ClientId, Constants.ClientSecret);
              AuthenticationResult authenticationResult = authenticationContext.AcquireToken(Constants.ResourceUrl, clientCred);
                string token = authenticationResult.AccessToken;
                return token;
            }
     ActiveDirectoryClient activeDirectoryClient = new ActiveDirectoryClient(new Uri(https://graph.windows.net, TenantId),
                    async () => await GetTokenForApplication());
