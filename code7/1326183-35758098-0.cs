    using System;
    
    using MailKit.Net.Smtp;
    using MailKit.Security;
    using MailKit;
    using MimeKit;
    
    namespace TestClient {
    	class Program
    	{
    		public static void Main (string[] args)
    		{
    			var message = new MimeMessage ();
    			message.From.Add (new MailboxAddress ("", "test.user@mydomain.com"));
    			message.To.Add (new MailboxAddress ("", "test.recipient@anotherdomain.com"));
    			message.Subject = "Test message";
    			
    			message.Body = new TextPart ("plain") { Text = "This is the message body." };
    			
    			using (var client = new SmtpClient (new ProtocolLogger ("smtp.log"))) {
    				client.Connect ("smtp.office365.com", 587, SecureSocketOptions.StartTls);
    				
    				client.Authenticate ("test.user@mydomain.com", "password");
    				
    				client.Send (message);
    				client.Disconnect (true);
    			}
    		}
    	}
    }
