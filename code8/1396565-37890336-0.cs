    void SendEmail(string SMTPServer, int SMTPPort, string SMTPUserName, string SMTPPassowrd, 
                  string FromEmailID, string ToEmailID, string Subject, string Body)
        {
            try
            {
                SmtpClient SmtpClient = new SmtpClient(SMTPServer, SMTPPort);
                SmtpClient.UseDefaultCredentials = false;
                SmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpClient.Credentials = new System.Net.NetworkCredential(SMTPUserName, SMTPPassowrd);
                MailMessage mailMsg = new MailMessage();
                mailMsg.From = new MailAddress(FromEmailID);
                mailMsg.To.Add(ToEmailID);
                mailMsg.Subject = Subject;
                mailMsg.Body = Body;
                mailMsg.IsBodyHtml = true;
                SmtpClient.Send(mailMsg);
            }
            catch
            {
 
                throw;
            }
        }
