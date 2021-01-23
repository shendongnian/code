     string[] scopes = 
              new string[] { 
                 AnalyticsService.Scope.Analytics,                 // view and manage your Google Analytics data
                 AnalyticsService.Scope.AnalyticsManageUsers};     // View Google Analytics data      
    
    string keyFilePath = @"c:\file.p12" ;    // found in developer console
    string serviceAccountEmail = "xx@developer.gserviceaccount.com";  // found in developer console
    //loading the Key file
    var certificate = new X509Certificate2(keyFilePath, "notasecret", X509KeyStorageFlags.Exportable);
    ServiceAccountCredential credential = new ServiceAccountCredential( new ServiceAccountCredential.Initializer(serviceAccountEmail)
                                                                      {
                                                                       Scopes = scopes
                                                                     }.FromCertificate(certificate));
    AnalyticsService service = new AnalyticsService(new BaseClientService.Initializer()
                {
                 HttpClientInitializer = credential,
                 ApplicationName = "Analytics API Sample",
                });
