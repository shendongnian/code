        string[] scopes = new string[] {
                AnalyticsService.Scope.Analytics,  // view and manage your Google Analytics data
                AnalyticsService.Scope.AnalyticsEdit,  // Edit and manage Google Analytics Account
                AnalyticsService.Scope.AnalyticsManageUsers,   // Edit and manage Google Analytics Users
                AnalyticsService.Scope.AnalyticsReadonly};     // View Google Analytics Data
        
        String CLIENT_ID = "6.apps.googleusercontent.com"; // found in Developer console
        String CLIENT_SECRET = "xxx";// found in Developer console
        // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
        UserCredential credential = 
                GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { 
                                                               ClientId = CLIENT_ID
                                                               , ClientSecret = CLIENT_SECRET 
                                                               }
                                                            , scopes
                                                            , Environment.UserName
                                                            , CancellationToken.None
                                                            , new FileDataStore("Daimto.GoogleAnalytics.Auth.Store")).Result;
    
    AnalyticsService service = new AnalyticsService(new BaseClientService.Initializer()
                {
                 HttpClientInitializer = credential,
                 ApplicationName = "Analytics API Sample",
                });
    
    DataResource.GaResource.GetRequest request = service.Data.Ga.Get("ga:8903098", "2014-01-01", "2014-01-01", "ga:sessions");
    request.MaxResults = 1000;
    GaData result = request.Execute();
