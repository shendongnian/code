    string clientId = "ddd";
    string clientSecret = "ddd";
       
    var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = clientId, ClientSecret = clientSecret }
                                                                                        , scopes
                                                                                        , "test"
                                                                                        , CancellationToken.None
                                                                                        , new FileDataStore(".",true)).Result;
    
       var service = new DoubleClickBidManagerService(new BaseClientService.Initializer()
           {
           HttpClientInitializer = credential,
           ApplicationName = "xyz",    
           });
