    using System;
    using System.Net.Mail;
    
    namespace SendMail
    {
        class Program
        {
            SmtpClient client = new SmtpClient("<internal ip address>");
            static void Main(string[] args)
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("<user name>", "<password>");
                //client.EnableSsl = true;
                //client.Port = 25;    
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                for (int i = 0; i < 100; i++)
                {
                    string html = "<h1>TEST</h1>";
    
                    using (MailMessage mail = new MailMessage("sender@domain.com", "receiver@domain.com"))
                    {
                        mail.Subject = "Test";
                        mail.IsBodyHtml = true;
                        mail.Body = html;
    
                        client.Send(mail);
                    }
                }
            }
        }
    }
