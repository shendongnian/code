        var initializer = new ServiceAccountCredential.Initializer("blablablabla@blabla.iam.gserviceaccount.com")
        {
            Scopes = scope,
            User = "emailToImpersonate@domain"
        };
        var credential = new ServiceAccountCredential(initializer.FromPrivateKey("-----BEGIN PRIVATE KEY-----\n-----END PRIVATE KEY-----\n"));
        var driveService = new DriveService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = ApplicationName
        });
