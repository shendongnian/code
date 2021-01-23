    var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
        {
            ClientSecrets = new ClientSecrets
                {
                    ClientId = ClientId,
                    ClientSecret = ClientSecret
                },
                Scopes = new[] { DriveService.Scope.Drive }
        });
    var credential = new UserCredential(_flow, request.UserIdentifier, new TokenResponse
        {
            AccessToken = AccessToken,
            RefreshToken = RefreshToken
        });
    var service = new DriveService(new BaseClientService.Initializer
        {
            ApplicationName = "MyApp",
            HttpClientInitializer = credential,
            DefaultExponentialBackOffPolicy = ExponentialBackOffPolicy.Exception | ExponentialBackOffPolicy.UnsuccessfulResponse503
        });
