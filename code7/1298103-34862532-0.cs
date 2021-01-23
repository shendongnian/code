    public Task SendEmailAsync(string email, string subject, string message)
    {
        // Plug in your email service here to send an email.
        var myMessage = new SendGrid.SendGridMessage();
        myMessage.AddTo(email);
        myMessage.From = new MailAddress("varshney@shobhit.com", "Shobhit", System.Text.Encoding.Default);
        myMessage.Subject = subject;
        myMessage.Text = message;
        myMessage.Html = message;
    
        var apiKey = Options.SendGridApiKey;
    
        // Create a Web transport for sending email.
        var transportWeb = new SendGrid.Web(apiKey);
        // Send the email.
        if (transportWeb != null)
        {
            return transportWeb.DeliverAsync(myMessage);
        }
        else
        {
            return Task.FromResult(0);
        }
    }
