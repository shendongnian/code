        public async static Task<AuthenticationResult> GetAccessTokenByCodeAsync(string signedInUserID, string code)
        {
                ClientCredential credential = new ClientCredential(clientId, appKey);
                AuthenticationContext authContext = new AuthenticationContext(AadInstance + TenantId, new ADALTokenCache(signedInUserID));
                AuthenticationResult result = await authContext.AcquireTokenByAuthorizationCodeAsync(
                code, new Uri(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Path)), credential, graphResourceId);
                return result;
        }
