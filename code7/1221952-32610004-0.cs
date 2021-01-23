     public static WebmastersService WMAuthenticateOauth(string clientId, string clientSecret, string userName)
            {
    
                string[] scopes = new string[] { WebmastersService.Scope.Webmasters };     // View analytics data
    
                try
                {
                    // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
                    UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = clientId, ClientSecret = clientSecret }
                                                                                                 , scopes
                                                                                                 , userName
                                                                                                 , CancellationToken.None
                                                                                                 , new FileDataStore(".", true)).Result;
    
                    WebmastersService service = new WebmastersService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "Drive API Sample",
                    });
                    return service;
                }
                catch (Exception ex)
                {
    
                    Console.WriteLine(ex.InnerException);
                    return null;
    
                }
    
            }
