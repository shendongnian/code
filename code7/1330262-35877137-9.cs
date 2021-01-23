    using System;
    
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
    
                    client.Authenticate ("user.name@gmail.com", "password");
    
                    for (int i = 0; i < client.Count; i++) {
                        var message = client.GetMessage (i);
                        // TODO: render the message
                    }
    
                    client.Disconnect (true);
                }
            }
        }
    }
