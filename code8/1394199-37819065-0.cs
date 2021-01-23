    static public void sendEmail(string nailFrom, string mailTo, string mailSubject, string mailBody, string userName, string userPassword)
        {
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    mail.From = new MailAddress(nailFrom);
                    mail.To.Add(mailTo);
                    mail.Subject = mailSubject;
                    mail.Body = mailBody;
                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(userName, userPassword);
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
