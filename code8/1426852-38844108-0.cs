     public static async Task<string> GetTokenByCert(string clientId, string tenant, string certThumbprint,string resource)
        {
            string authority = $"https://login.windows.net/{tenant}";
            X509Certificate2 cert = CertHelper.FindCert(certThumbprint);
            var certCred = new ClientAssertionCertificate(clientId, cert);
            var authContext = new Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext(authority);
            AuthenticationResult result = null;
            try
            {
                result = await authContext.AcquireTokenAsync(resource, certCred);
            }
            catch (Exception ex)
            {
            }
            return result.AccessToken;
        }
