    using System;
    using System.Threading;
    using System.Security.Cryptography.X509Certificates;
    
    using Google.Apis.Auth.OAuth2;
    
    using MimeKit;
    using MailKit.Net.Smtp;
    using MailKit.Security;
    
    namespace Example {
    	class Program
    	{
    		public static async void Main (string[] args)
    		{
    			var certificate = new X509Certificate2 (@"C:\path\to\certificate.p12", "password", X509KeyStorageFlags.Exportable);
    			var credential = new ServiceAccountCredential (new ServiceAccountCredential
    				.Initializer ("your-developer-id@developer.gserviceaccount.com") {
    					// Note: other scopes can be found here: https://developers.google.com/gmail/api/auth/scopes
    					Scopes = new[] { "https://mail.google.com/" },
    					User = "username@gmail.com"
    				}.FromCertificate (certificate));
    
    			// Note: result will be true if the access token was received successfully
    			bool result = await credential.RequestAccessTokenAsync (CancellationToken.None);
    
    			if (!result) {
    				Console.WriteLine ("Error fetching access token!");
    				return;
    			}
    
    			var message = new MimeMessage ();
    			message.From.Add (new MailboxAddress ("Your Name", "username@gmail.com"));
    			message.To.Add (new MailboxAddress ("Recipient's Name", "recipient@yahoo.com"));
    			message.Subject = "This is a test message";
    
    			var builder = new BodyBuilder ();
    			builder.TextBody = "This is the body of the message.";
    			builder.Attachments.Add (@"C:\path\to\attachment");
    
    			message.Body = builder.ToMessageBody ();
    
    			using (var client = new SmtpClient ()) {
    				client.Connect ("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
    
    				// use the access token as the password string
    				client.Authenticate ("username@gmail.com", credential.Token.AccessToken);
    
    				client.Send (message);
    
    				client.Disconnect (true);
    			}
    		}
    	}
    }
