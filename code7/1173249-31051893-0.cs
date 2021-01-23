    /// <summary>
            /// Authenticate to Google Using Oauth2
            /// Documentation https://developers.google.com/accounts/docs/OAuth2
            /// </summary>
            /// <param name="clientId">From Google Developer console https://console.developers.google.com</param>
            /// <param name="clientSecret">From Google Developer console https://console.developers.google.com</param>
            /// <param name="userName">A string used to identify a user.</param>
            /// <returns></returns>
            public static WebmastersService  AuthenticateOauth(string clientId, string clientSecret, string userName)
            {
                
                string[] scopes = new string[] { WebmastersService.Scope.WebmastersReadonly};     // View analytics data
    
                try
                {
                    // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
                    UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = clientId, ClientSecret = clientSecret }
                                                                                                 , scopes
                                                                                                 , userName
                                                                                                 , CancellationToken.None
                                                                                                 , new FileDataStore("Daimto.GoogleWebMasters.Auth.Store")).Result;
    
                    WebmastersService service = new WebmastersService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "WebMasters API Sample",
                    });
                    return service;
                }
                catch (Exception ex)
                {
    
                    Console.WriteLine(ex.InnerException);
                    return null;
    
                }
    
            }
    
