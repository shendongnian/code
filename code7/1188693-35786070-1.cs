    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            SmtpClient client = new SmtpClient();
            return client.SendMailAsync(ConfigurationManager.AppSettings["SupportEmailAddr"], 
                                        message.Destination, 
                                        message.Subject, 
                                        message.Body);
        }
    }
