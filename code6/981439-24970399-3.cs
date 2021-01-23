    using System;
    using MimeKit;
    using MailKit.Net.Smtp;
    
    public class SMTPMailHelper
    {
        const string SMTPServer = "mail.mydomain.com";
        const string SMTPUserId = "myemail@mydomain.com";
        const string SMTPPassword = "MyPasswordHidden";
        const int SMTPPort = 25;
        
        public static void SendMail(string sendFrom, string sendTo, string subject, string body)
        {
            MimeMessage message = new MimeMessage ();
            TextPart text;
            
            message.From.Add (new MailboxAddress ("", sendFrom));
            message.To.Add (new MailboxAdress ("", sendTo));
            message.Subject = subject;
            
            if (body.ToLower ().Contains ("<html>"))
                text = new TextPart ("html") { Text = text };
            else
                text = new TextPart ("plain") { Text = text };
            
            message.Body = text;
            
            using (var smtp = new SmtpClient ()) {
                // use the IP address gotten from http://www.whatismyip.com/
                // or the hostname gotten from http://www.displaymyhostname.com/
                smtp.LocalDomain = "c-24-71-150-91.hsd1.ga.comcast.net";
                
                smtp.Connect (SMTPServer, SMTPPort, false);
                smtp.Authenticate (SMTPUserId, SMTPPassword);
                smtp.Send (message);
                smtp.Disconnect (true);
            }
        }
    }
