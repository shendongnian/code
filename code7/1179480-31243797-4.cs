    /// <summary>
            /// Authenticate to Google Using Oauth2
            /// Documentation https://developers.google.com/accounts/docs/OAuth2
            /// </summary>
            /// <param name="clientId">From Google Developer console https://console.developers.google.com</param>
            /// <param name="clientSecret">From Google Developer console https://console.developers.google.com</param>
            /// <param name="userName">A string used to identify a user.</param>
            /// <returns></returns>
            public static DriveService AuthenticateOauth(string clientId, string clientSecret, string userName)
            {
    
                //Google Drive scopes Documentation:   https://developers.google.com/drive/web/scopes
                string[] scopes = new string[] {                                                  DriveService.Scope.DriveFile   // view and manage files created by this app
    };                                                
    
                try
                {
                    // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
                    UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = clientId, ClientSecret = clientSecret }
                                                                                                 , scopes
                                                                                                 , userName
                                                                                                 , CancellationToken.None
                                                                                                 , new FileDataStore("Daimto.Drive.Auth.Store")).Result;
    
                    DriveService service = new DriveService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "Daimto Drive API Sample",
                    });
                    return service;
                }
                catch (Exception ex)
                {
    
                    Console.WriteLine(ex.InnerException);
                    return null;
    
                }
    
               }
