    using System;
    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Gmail.v1;
    using Google.Apis.Services;
    using Google.Apis.Util.Store;
    using System.IO;
    using System.Threading;
    using System.Net.Mail;
    
    namespace SendStatusReportsAddin1
    {
        class Program
        {
            // If modifying these scopes, delete your previously saved credentials
            // at ~/.credentials/gmail-dotnet-quickstart.json
            //static string[] Scopes = { GmailService.Scope.GmailReadonly };
            static string[] Scopes = { GmailService.Scope.MailGoogleCom };
            static string ApplicationName = "Gmail API .NET Quickstart";
    
            static void Main(string[] args)
            {
                //Authorization
                  UserCredential credential;
    
                  using (var stream =
                      new FileStream("client_secret2.json", FileMode.Open, FileAccess.Read))
                  {
                      string credPath = System.Environment.GetFolderPath(
                          System.Environment.SpecialFolder.Personal);
                      credPath = Path.Combine(credPath, ".credentials3/gmail-dotnet.json");
    
                      credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                          GoogleClientSecrets.Load(stream).Secrets,
                          Scopes,
                          "user",
                          CancellationToken.None,
                          new FileDataStore(credPath, true)).Result;
                      Console.WriteLine("Credential file saved to: " + credPath);
                  }
    
                //Create Gmail API service.
                  var service = new GmailService(new BaseClientService.Initializer()
                  {
                      HttpClientInitializer = credential,
                      ApplicationName = ApplicationName,
                  });
    
                //Create mail message
                  MailMessage mailmsg = new MailMessage();
                  {
                      mailmsg.Subject = "My test subject";
                      mailmsg.Body = "<b>My smart message </b>";
                      mailmsg.From = new MailAddress("joe.blow@hotmail.com");
                      mailmsg.To.Add(new MailAddress("jeff.jones@gmail.com"));
                      mailmsg.IsBodyHtml = true;
                  }
    
                //add attachment
                  string statusreportfile =
                            @"C:\Users\ey96a\Google Drive\10 Status-Vacation-Expense\Status Reports\UUM RewriteStatus Report.pdf";
    
                  Attachment data = new Attachment(statusreportfile);
                  mailmsg.Attachments.Add(data);
    
                //Make mail message a Mime message
                  MimeKit.MimeMessage mimemessage = MimeKit.MimeMessage.CreateFromMailMessage(mailmsg);
    
                //Use Base64URLEncode to encode the Mime message
                  Google.Apis.Gmail.v1.Data.Message finalmessage = new Google.Apis.Gmail.v1.Data.Message();
                  finalmessage.Raw = Base64UrlEncode(mimemessage.ToString());
    
                //Create the draft email
                  var mydraft = new Google.Apis.Gmail.v1.Data.Draft();
                  mydraft.Message = finalmessage;
    
                  var resultdraft = service.Users.Drafts.Create(mydraft, "me").Execute();
    
                //Send the email (instead of creating a draft)
                  var resultsend = service.Users.Messages.Send(finalmessage, "me").Execute();
    
                //Open the SendStatusReports form
                  aOpenForm.myForm1();
    
            }  //end of Main
    
            //Base64 URL encode
            public static string Base64UrlEncode(string input)
            {
                var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
                // Special "url-safe" base64 encode.
    
                return System.Convert.ToBase64String(inputBytes)
                    .Replace('+', '-')
                    .Replace('/', '_')
                    .Replace("=", "");
            }
    
        } //end of class Program
    
    }
