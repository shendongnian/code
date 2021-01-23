    /// <summary>
            /// The Google APIs Client Library for .net uses the client_secrets.json file format for storing the client_id, client_secret, and other OAuth 2.0 parameters.
            /// The client_secrets.json file format is a JSON formatted file containing the client ID, client secret, and other OAuth 2.0 parameters.
            ///      
            /// This file can be obtained from Google Developers console:   https://console.developers.google.com/project?authuser=0
            /// </summary>
            /// <param name="clientSecretJson">Path to the client secret json file from Google Developers console.</param>
            /// <param name="userName">The user to authorize.</param>
            /// <returns>a valid CalendarService</returns>
            public static CalendarService AuthenticateOauth(string clientSecretJson, string userName)
            {
                if (string.IsNullOrEmpty(userName))
                    throw new Exception("userName is required for datastore.");
    
                if (!File.Exists(clientSecretJson))
                    throw new Exception("Cant find Client Secret Json file.");
    			
                string[] scopes = new string[] {  CalendarService.Scope.Calendar,            // Manage your calendars
                                                 CalendarService.Scope.CalendarReadonly, // View your calendars
                                                 "https://www.google.com/m8/feeds/",
                                                 "https://apps-apis.google.com/a/feeds/groups/"};                  
   
             try
                {
                    UserCredential credential;
                    using (var stream = new FileStream(clientSecretJson, FileMode.Open, FileAccess.Read))
                    {
                        string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                        credPath = Path.Combine(credPath, ".credentials/Calendar");
    
                        credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                            GoogleClientSecrets.Load(stream).Secrets,
                            scopes,
                            userName,
                            CancellationToken.None,
                            new FileDataStore(credPath, true)).Result;
                        Console.WriteLine("Credential file saved to: " + credPath);
                    }
    
                    // Create Calendar API service.
                    var service = new CalendarService(new BaseClientService.Initializer()
                        {
                            HttpClientInitializer = credential,
                            ApplicationName = "Calendar Authentication Sample",
                        });
                    return service;
                }
                catch (Exception ex)
                {
    
                    Console.WriteLine(ex.InnerException);
                    throw ex;
    
                }
            }
