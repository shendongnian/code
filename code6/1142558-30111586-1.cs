    using System.Net;
    using System.Net.Mail;
    
    namespace consSendMail
    {
        class Program
        {
            static void Main(string[] args)
            {
                SmtpClient smtpClient = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    Credentials = new NetworkCredential("yourmail", "yourpassword")
                };
    
                var mailMessage = new MailMessage();
                mailMessage.Subject = "Subject";
                mailMessage.From = new MailAddress("yourmail", "yourname");
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = "your message";            
                mailMessage.To.Add( new MailAddress("destinationemail") );
    
                smtpClient.Send(mailMessage);
    
            }
        }
    }
