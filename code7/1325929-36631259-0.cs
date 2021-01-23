    private AnalyticsReportingService service;
    public async Task GetAuthorizationByServiceAccount()
        {
            string[] scopes = new string[] { AnalyticsReportingService.Scope.AnalyticsReadonly }; // Put your scopes here
            var keyFilePath = AppContext.BaseDirectory + @"KeyFile.json";
            //Console.WriteLine("Key File: " + keyFilePath);
            var stream = new FileStream(keyFilePath, FileMode.Open, FileAccess.Read);
            var credential = GoogleCredential.FromStream(stream);
            credential = credential.CreateScoped(scopes);
            service = new AnalyticsReportingService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "<Your App Name here>",
            });
        }
