    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Auth.OAuth2.Responses;
    using Google.Apis.Auth.OAuth2.Flows;
    
    string[] scopes = new string[] {
        YouTubeService.Scope.Youtube,
        YouTubeService.Scope.YoutubeUpload
    };
    GoogleAuthorizationCodeFlow flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
    {
        ClientSecrets = new ClientSecrets
        {
            ClientId = XXXXXXXXXX,  <- Put your own values here
            ClientSecret = XXXXXXXXXX  <- Put your own values here
        },
        Scopes = scopes,
        DataStore = new FileDataStore("Store")
    });
    TokenResponse token = new TokenResponse {
        AccessToken = lblActiveToken.Text,
        RefreshToken = lblRefreshToken.Text
    };
    UserCredential credential = new UserCredential(flow, Environment.UserName, token);
 
