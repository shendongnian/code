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
                string[] scopes = new string[] { DriveService.Scope.Drive,  // view and manage your files and documents
                                                 DriveService.Scope.DriveAppdata,  // view and manage its own configuration data
                                                 DriveService.Scope.DriveAppsReadonly,   // view your drive apps
                                                 DriveService.Scope.DriveFile,   // view and manage files created by this app
                                                 DriveService.Scope.DriveMetadataReadonly,   // view metadata for files
                                                 DriveService.Scope.DriveReadonly,   // view files and documents on your drive
                                                 DriveService.Scope.DriveScripts };  // modify your app scripts
                                              
    
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
