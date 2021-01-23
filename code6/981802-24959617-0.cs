    public class Mailer
    {
        public static void Send(MailMessage mailMessage)
        {
            using (SmtpClient client = new SmtpClient())
            {
                client.Port = 25;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "smtp.google.com";
                client.Send(mailMessage);
            }
        }
    }
