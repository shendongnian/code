    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.IO;
    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Gmail.v1;
    using Google.Apis.Gmail.v1.Data;
    using Google.Apis.Services;
    using Google.Apis.Util.Store;
    
    namespace GmailTests
    {
        class Program
        {
            // If modifying these scopes, delete your previously saved credentials
            // at ~/.credentials/gmail-dotnet-quickstart.json
            static string[] Scopes = { GmailService.Scope.GmailModify };
            static string ApplicationName = "Gmail API .NET Quickstart";
    
            static void Main(string[] args)
            {
                UserCredential credential;
    
                using (var stream =
                    new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = System.Environment.GetFolderPath(
                        System.Environment.SpecialFolder.Personal);
                    credPath = Path.Combine(credPath, ".credentials/gmail-dotnet-quickstart2.json");
    
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
    
                
                var re = service.Users.Messages.List("me");
                re.LabelIds = "INBOX";
                re.Q = "is:unread"; //only get unread;
    
                var res = re.Execute();
    
                if (res != null && res.Messages != null)
                {
                    Console.WriteLine("there are {0} emails. press any key to continue!", res.Messages.Count);
                    Console.ReadKey();
    
                    foreach (var email in res.Messages)
                    {
                        var emailInfoReq = service.Users.Messages.Get("me", email.Id);
                        var emailInfoResponse = emailInfoReq.Execute();
    
                        if (emailInfoResponse != null)
                        {
                            String from = "";
                            String date = "";
                            String subject = "";
                            String body = "";
                            //loop through the headers and get the fields we need...
                            foreach (var mParts in emailInfoResponse.Payload.Headers)
                            {
                                if (mParts.Name == "Date")
                                {
                                    date = mParts.Value;
                                }
                                else if (mParts.Name == "From")
                                {
                                    from = mParts.Value;
                                }
                                else if (mParts.Name == "Subject")
                                {
                                    subject = mParts.Value;
                                }
    
                                if (date != "" && from != "")
                                {
                                    if (emailInfoResponse.Payload.Parts == null && emailInfoResponse.Payload.Body != null)
                                        body = DecodeBase64String(emailInfoResponse.Payload.Body.Data);
                                    else
                                        body = GetNestedBodyParts(emailInfoResponse.Payload.Parts, "");
                                    
                                    //now you have the data you want....
    
                                }
    
                            }
    
                            //Console.Write(body);
                            Console.WriteLine("{0}  --  {1}  -- {2}", subject, date, email.Id);
                            Console.ReadKey();
                        }
                    }
                }
            }
    
            static String DecodeBase64String(string s)
            {
                var ts = s.Replace("-", "+");
                ts = ts.Replace("_", "/");
                var bc = Convert.FromBase64String(ts);
                var tts = Encoding.UTF8.GetString(bc);
    
                return tts;
            }
    
            static String GetNestedBodyParts(IList<MessagePart> part, string curr)
            {
                string str = curr;
                if (part == null)
                {
                    return str;
                }
                else
                {
                    foreach (var parts in part)
                    {
                        if (parts.Parts == null)
                        {
                            if (parts.Body != null && parts.Body.Data != null)
                            {
                                var ts = DecodeBase64String(parts.Body.Data);
                                str += ts;
                            }
                        }
                        else
                        {
                            return GetNestedBodyParts(parts.Parts, str);
                        }
                    }
    
                    return str;
                }
            }
        }
    }
    
