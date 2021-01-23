    private void sendEmail(string recepientEmailAddress) {
            string subjectEmail = "Subject Email";
            MailAddress to = new MailAddress("example@email.com");
            MailAddress from = new MailAddress("example@example.com");
    
            MailMessage message = new MailMessage(from, to);
            message.Subject = subjectEmail;
            message.IsBodyHtml = true;
            message.Body = "Body example";
    
            try
            {
                SmtpClient sc = new SmtpClient(ConfigurationManager.AppSettings["MailServer"].ToString());
                sc.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                sc.EnableSsl = true;
                sc.Host="smtp.gmail.com"
                sc.port = 587;
                sc.UseDefaultCredentials = true;
                sc.Send(message);
            }
            catch (Exception e)
            {
                Helpers.ErrorLogger.ProcessError(e.Message, e.StackTrace, "RegistrationController", "SendEmail");
            }
        }
