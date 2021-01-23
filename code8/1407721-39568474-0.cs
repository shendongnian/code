    namespace TestingMailMessage
    {
        using System.Net;
        using System.Net.Mail;
    
        public class Program
        {
            public static void Main(string[] args)
            {
                const string FromEmail = "<some-email-address>";
                const string Password = "<your-password>";
    
                var mailMessage = new MailMessage(
                    FromEmail,
                    "xxxxxxxxxx@invite.trustpilot.com",
                    "This is a test trigger",
                    "<script type=\"application/json+trustpilot\">{\"recipientEmail\": \"jane.doe@trustpilot.com\"}</script>");
    
                var smtpClient = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(FromEmail, Password)
                    };
    
                smtpClient.Send(mailMessage);
            }
        }
    }
