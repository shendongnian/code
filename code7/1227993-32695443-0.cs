    public class MailHandler
    {
    public bool SendEMail(string smtpHost ="smtp.gmail.com", int port = 587, string senderMail , string  senderPass, ArrayList mailToArr, string subject, bool isHtml, string body)
        {
            try
            {
                
                SmtpClient smtpClient = new SmtpClient(smtpHost, port);
                smtpClient.UseDefaultCredentials = false;// true;
                smtpClient.Credentials = new System.Net.NetworkCredential(senderMail, senderPass);
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderMail);
                for (int i = 0; i < mailToArr.Count; i++)
                {
                    mail.To.Add(new MailAddress((string)mailToArr[i]));
                }
                mail.Subject = subject;
                //mail.CC.Add(new MailAddress("MyEmailID@gmail.com"));
                mail.Body = body;
                mail.IsBodyHtml = isHtml;
                mail.Priority = MailPriority.Normal;
                smtpClient.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                
                // write exception on server log
            }
        }
    }
