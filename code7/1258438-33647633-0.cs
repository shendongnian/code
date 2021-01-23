    string[] scopes = new string[] { YouTubeService.Scope.Youtube };
     // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
    UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = clientId, ClientSecret = clientSecret }
    , scopes
    , "test"
    , CancellationToken.None
    , new FileDataStore("Daimto.YouTube.Auth.Store")).Result;
    
    YouTubeService service = new YouTubeService(new YouTubeService.Initializer()
         {
         HttpClientInitializer = credential,
         ApplicationName = "YouTube Data API Sample",
         });
