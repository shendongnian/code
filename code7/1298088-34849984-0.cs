     /// <summary>
            /// Authenticate to Google Using Oauth2
            /// Documentation https://developers.google.com/accounts/docs/OAuth2
            /// </summary>
            /// <param name="clientId">From Google Developer console https://console.developers.google.com</param>
            /// <param name="clientSecret">From Google Developer console https://console.developers.google.com</param>
            /// <param name="userName">The user to authorize.</param>
            /// <returns>a valid DriveService</returns>
            public static DriveService AuthenticateOauth(string clientId, string clientSecret, string userName)
            {
                if (string.IsNullOrEmpty(clientId))
                    throw new Exception("clientId is required.");
                if (string.IsNullOrEmpty(clientSecret))
                    throw new Exception("clientSecret is required.");
                if (string.IsNullOrEmpty(userName))
                    throw new Exception("userName is required for datastore.");
    
                
                string[] scopes = new string[] { DriveService.Scope.Drive};
    
                try
                {
    
                    string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    credPath = Path.Combine(credPath, ".credentials/Drive");
    
                    // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
                    UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = clientId, ClientSecret = clientSecret }
                                                                                                 , scopes
                                                                                                 , userName
                                                                                                 , CancellationToken.None
                                                                                                 , new FileDataStore(credPath, true)).Result;
    
                    var service = new DriveService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = "Drive Authentication Sample",
                    });
                    return service;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                    throw ex;
                }
    
            }
    /// <summary>
            /// Insert a new file.
    		/// Documentation: https://developers.google.com/drive//v2/files/insert
    		/// </summary>
    		/// <param name="service">Valid authentcated DriveService</param>
    		/// <param name="body">Valid File Body</param>
    		/// <returns>File </returns>
    	    public static File Insert(DriveService service, File body)
    	    {
    		    //Note Genrate Argument Exception (https://msdn.microsoft.com/en-us/library/system.argumentexception(loband).aspx)
    		    try
                {  
    			return 			service.Files.Insert(body).Execute();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Request Failed " + ex.Message);
                    throw ex;
                }
    		 }
      private static string GetMimeType(string fileName)
            {
                string mimeType = "application/unknown";
                string ext = System.IO.Path.GetExtension(fileName).ToLower();
                Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
                if (regKey != null && regKey.GetValue("Content Type") != null)
                    mimeType = regKey.GetValue("Content Type").ToString();
                return mimeType;
            }
