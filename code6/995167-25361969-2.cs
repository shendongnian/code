    using System;
    using System.Linq;
    
    using MailKit.Net.Pop3;
    using MailKit;
    using MimeKit;
    
    namespace TestClient {
        class Program
        {
            public static void Main (string[] args)
            {
                using (var client = new Pop3Client ()) {
                    client.Connect ("pop.gmail.com", 995, true);
                    
                    // Note: since we don't have an OAuth2 token, disable
                    // the XOAUTH2 authentication mechanism.
                    client.AuthenticationMechanisms.Remove ("XOAUTH2");
                    
                    client.Authenticate ("joey@gmail.com", "password");
                    
                    int count = client.GetMessageCount ();
                    int unknown = 0;
                    
                    for (int i = 0; i < count; i++) {
                        var message = client.GetMessage (i);
                        
                        foreach (var attachment in message.Attachments.OfType<TextPart> ()) {
                            var fileName = attachment.FileName ?? string.Format ("unknown{0}.txt", ++unknown);
                            
                            // Save the content of the attachment in whatever
                            // charset it is in.
                            using (var stream = File.Create (fileName))
                                attachment.ContentObject.DecodeTo (stream);
                        }
                    }
                    
                    client.Disconnect (true);
                }
            }
        }
    }
