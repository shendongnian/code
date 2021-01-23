    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            //create a client, it should pick up the settings from web.config
            var client = new SmtpClient();
            //now construct a MailMessage object from the message and send it with the SmtpClient.
            var email = new MailMessage("donotreply@mysite.com", message.Destination, message.Subject, message.Body);
            //send the email asynchronously
            await client.SendMailAsync(email);
            return Task.FromResult(0);
        }
    }
