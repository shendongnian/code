    /// <summary>
    /// Authenticate to Google Using Oauth2
    /// Documentation https://developers.google.com/accounts/docs/OAuth2
    /// </summary>
    /// <param name="clientId">From Google Developer console https://console.developers.google.com</param>
    /// <param name="clientSecret">From Google Developer console https://console.developers.google.com</param>
    /// <param name="userName">A string used to identify a user.</param>
    /// <returns></returns>
    public static BigqueryService  AuthenticateOauth(string clientId, string clientSecret, string userName)
    {
        string[] scopes = new string[] { BigqueryService.Scope.Bigquery,                // view and manage your BigQuery data
                                         BigqueryService.Scope.BigqueryInsertdata ,     // Insert Data into Big query
                                         BigqueryService.Scope.CloudPlatform,           // view and manage your data acroos cloud platform services
                                         BigqueryService.Scope.DevstorageFullControl,   // manage your data on Cloud platform services
                                         BigqueryService.Scope.DevstorageReadOnly ,     // view your data on cloud platform servies
                                         BigqueryService.Scope.DevstorageReadWrite };   // manage your data on cloud platform servies
        try
        {
            // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
            UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = clientId, ClientSecret = clientSecret }
                                                                                         , scopes
                                                                                         , userName
                                                                                         , CancellationToken.None
                                                                                         , new FileDataStore("Daimto.BigQuery.Auth.Store")).Result;
            BigqueryService service = new BigqueryService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "BigQuery API Sample",
            });
            return service;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.InnerException);
            return null;
        }
    }
