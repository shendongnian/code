    public async Task AuthorizeAsync()
    {
       ClientSecrets client = new ClientSecrets
       {
           ClientId = SessionState.
                            SystemSettings[SystemSettingKey.GoogleAccountClientId].Value,
           ClientSecret = SessionState.
                            SystemSettings[SystemSettingKey.GoogleAccountClientSecret].Value
    
       };
    
       IList<string> scopes = new List<string>();
       scopes.Add(CalendarService.Scope.Calendar);
       var credPath = HttpContext.Current.Server.MapPath("~/App_Data/");  
        
       var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                                     client, 
                                     scopes, 
                                     account,
                                     CancellationToken.None,
                                     new FileDataStore(credPath, true));
    
       // Create the calendar service using an initializer instance
       BaseClientService.Initializer initializer = new BaseClientService.Initializer
       {
          HttpClientInitializer = credential,
          ApplicationName = "App1"
       };
    }
