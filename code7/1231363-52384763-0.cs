       namespace GmailAPIApp
       {
            class SendMail
            {
                  static string[] Scopes = { GmailService.Scope.GmailSend };
                  static string ApplicationName = "Gmail API .NET Quickstart";
                 static void Main(string[] args)
                 {
                    UserCredential credential;
                    using (var stream =
                    new FileStream("credentials_dev.json", FileMode.Open, 
                      FileAccess.Read))
                    {
                       string credPath = "token_Send.json";
                       credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                                    GoogleClientSecrets.Load(stream).Secrets,
                                     Scopes,
                                     "user",
                                     CancellationToken.None,
                                     new FileDataStore(credPath, true)).Result;
                     Console.WriteLine("Credential file saved to: " + credPath);
                   }
            // Create Gmail API service.
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            // Define parameters of request.           
            string plainText = "To:xxxx@gmail.com\r\n" +
                             "Subject: Gmail Send API Test\r\n" +
                             "Content-Type: text/html; charset=us-ascii\r\n\r\n" +
                             "<h1>TestGmail API Testing for sending <h1>";                          
            var newMsg = new Google.Apis.Gmail.v1.Data.Message();
            newMsg.Raw = SendMail.Base64UrlEncode(plainText.ToString());
            service.Users.Messages.Send(newMsg, "me").Execute();
            Console.Read();
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
        }   
     }
