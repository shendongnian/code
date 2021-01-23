          static string[] Scopes = { GmailService.Scope.GmailCompose, GmailService.Scope.GmailSend, GmailService.Scope.GmailInsert };
  
                static private BaseClientService.Initializer initializeGmailAccountServices()
                {
                    string appRoot = null;
                    
        
                        if (System.Web.HttpContext.Current == null)
                        {
                            appRoot = Environment.CurrentDirectory;
                        }
                        else
                        {
                            appRoot = System.Web.HttpContext.Current.Server.MapPath(@"~\");
                        }
                        string path = Path.Combine(appRoot, DBConstants.GMAIL_CREDENTIALS_PATH);
        
        
                        UserCredential credential;
                       
                        using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                        {
                            ClientSecrets secrets = GoogleClientSecrets.Load(stream).Secrets;
                            
                            var t =  GoogleWebAuthorizationBroker.AuthorizeAsync(secrets, Scopes, "user", CancellationToken.None);
                 
                            t.Wait();
                            credential = t.Result;
                        }
                        
                        return= new BaseClientService.Initializer()
                        {
                            HttpClientInitializer = credential,
                            ApplicationName = "your application name",
                        };
                }
    
    private static string Base64UrlEncode(string input)
                {
                    var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
                    // Special "url-safe" base64 encode.
                    return Convert.ToBase64String(inputBytes)
                      .Replace('+', '-')
                      .Replace('/', '_')
                      .Replace("=", "");
                }
