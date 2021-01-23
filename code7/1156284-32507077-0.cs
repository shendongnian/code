    public object GetGoogleApiAccessToken(IEnumerable<string> scopes, string mapPath)
    {
        try
        {
            var keyFilePath = mapPath + WebConfigurationManager.AppSettings["keyFilePath"];
    
            // found in developer console
            var serviceAccountEmail = WebConfigurationManager.AppSettings["serviceAccountEmail"];
    
            var certificate = new X509Certificate2(keyFilePath, "notasecret", X509KeyStorageFlags.Exportable);
    
            var credential =
                new ServiceAccountCredential(new ServiceAccountCredential.Initializer(serviceAccountEmail)
                    //create credential using certificate
                {
                    Scopes = scopes
                }.FromCertificate(certificate));
    
            credential.RequestAccessTokenAsync(CancellationToken.None).Wait(); //request token
    
            return credential.Token.AccessToken;
        }
        catch (Exception err)
        {
            Debug.WriteLine(err.Message);
    
            return null;
        }
    }
