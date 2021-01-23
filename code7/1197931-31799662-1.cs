    public class Gmail
    {
    public Gmail(ClientSecrets secrets, string appName)
            {
                applicationName = appName;
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(secrets,
                        new[] { GmailService.Scope.MailGoogleCom, GmailService.Scope.GmailCompose, GmailService.Scope.GmailReadonly },
                        "user", CancellationToken.None).Result; 
              
                service = new GmailService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = applicationName,
                });
            }
    public void SendEmail(System.Net.Mail.MailMessage mail)
            {
                var mimeMessage = MimeKit.MimeMessage.CreateFromMailMessage(mail);
                Message msg = new Message()
                {
                    Raw = Base64UrlEncode(mimeMessage.ToString())
                };
    
                SendMessage(service, msg);
            }
    
            private Message SendMessage(GmailService service, Message msg)
            {
                try 
                {
                    return service.Users.Messages.Send(msg, userid).Execute();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
    
            private string Base64UrlEncode(string input)
            {
                var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
                // Special "url-safe" base64 encode.
                return Convert.ToBase64String(inputBytes)
                  .Replace('+', '-')
                  .Replace('/', '_')
                  .Replace("=", "");
            }
    }
