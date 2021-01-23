    public class TestEmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            // Create the email object first, then add the properties.
            var myMessage = new MailMessage();
            // this defines email and name of the sender
            //myMessage.From = new MailAddress("no-reply@tech.trailmax.info", "My Awesome Admin");
    
            // set where we are sending the email
            myMessage.To.Add(message.Destination);
            myMessage.Subject = message.Subject;
            myMessage.IsBodyHtml = true;
            // make sure all your messages are formatted as HTML
            myMessage.Body = message.Body;
    
            // Create credentials, specifying your SendGrid username and password.
            var credentials = new NetworkCredential("SendGrid_Username", "SendGrid_Password");
    
            using (var client = new SmtpClient())
            {
                await client.SendMailAsync(myMessage);
            }
        }
    }
