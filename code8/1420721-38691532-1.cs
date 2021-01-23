       public static async Task<string> GetTokenAsync(string resource, string clientId, string secrect)
        {
            string authority = "https://login.microsoftonline.com/{yourTenantName}";
            AuthenticationContext authContext = new AuthenticationContext(authority);
            ClientCredential clientCredential = new ClientCredential(clientId, secrect);
            AuthenticationResult authResult=await authContext.AcquireTokenAsync(resource, clientCredential);
            return authResult.AccessToken;
        }
