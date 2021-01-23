    using System;
    
    using MailKit.Net.Smtp;
    using MailKit;
    using MimeKit;
    
    namespace TestClient {
        class Program
        {
            public static void Main (string[] args)
            {
                var message = new MimeMessage ();
                message.From.Add (new MailboxAddress ("Joey Tribbiani", "joey@friends.com"));
                message.To.Add (new MailboxAddress ("Mrs. Chanandler Bong", "chandler@friends.com"));
                message.Subject = "How you doin'?";
    
                message.Body = new TextPart ("plain") {
                    Text = @"Hey Chandler,
    
    I just wanted to let you know that Monica and I were going to go play some paintball, you in?
    
    -- Joey"
                };
    
                using (var client = new SmtpClient ()) {
                    client.Connect ("smtp.friends.com", 587, false);
    
                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate ("joey", "password");
    
                    client.Send (message);
                    client.Disconnect (true);
                }
            }
        }
    }
