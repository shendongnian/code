     var subscriptionId = "1a11aa11-5c9b-4c94-b875-b7b55af5d316";
            string tenant = "1a11111a-5713-4b00-a1c3-88da50be3ace";
            string clientId = "aa11a111-1050-4892-a2d8-4747441be14d";
            
            var authContext = new AuthenticationContext(string.Format("https://login.windows.net/{0}", tenant));
            X509Certificate2 cert = null;
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            string certName = "MyCert01";
            try
            {
                store.Open(OpenFlags.ReadOnly);
                var certCollection = store.Certificates;
                var certs = certCollection.Find(X509FindType.FindBySubjectName, certName, false);
                //var certs = certCollection.Find(X509FindType.FindBySerialNumber, "E144928868B609D35F72", false);
                if (certs == null || certs.Count <= 0)
                {
                    throw new Exception("Certificate " + certName + " not found.");
                }
                cert = certs[0];
            }
            finally
            {
                store.Close();
            }
            var certCred = new ClientAssertionCertificate(clientId, cert);
            var token = authContext.AcquireToken("https://management.core.windows.net/", certCred);
            var creds = new TokenCloudCredentials(subscriptionId, token.AccessToken);
            //var client = new ResourceManagementClient(creds); 
            return token.AccessToken;
