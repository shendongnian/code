    UserCredential credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
        new ClientSecrets
        {
            ClientId = "ID",
            ClientSecret = "Secret"
        },
        new[] { YouTubeService.Scope.YoutubeUpload },
        "12345",
        CancellationToken.None, 
        new EFDataStore(-1) // My own implementation of IDataStore
                );
        // This bit checks if the token is out of date, 
        // and refreshes the access token using the refresh token.
        if(credential.Token.IsExpired(SystemClock.Default))
        {
            if (!await credential.RefreshTokenAsync(CancellationToken.None))
            {
                Console.WriteLine("No valid refresh token.");
            }
        }            
            
        var service = new YouTubeService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = "MY App"
        });
