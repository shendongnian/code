    var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
    var client = new SendGridClient(apiKey);
    var msg = new SendGridMessage()
    {
        From = new EmailAddress("sender@email.com", "Sender Name"),
        Subject = "Subject",
        PlainTextContent = "Text for body",
        HtmlContent = "<strong>Hello World!",
        Personalizations = new List<Personalization>
        {
             new Personalization
             {
                  Tos = new List<EmailAddress> 
                  {
                       new EmailAddress("abc@email.com", "abc"),
                       new EmailAddress("efg@email.com", "efg")
                  }
             }
         }
    };
    var response = await client.SendEmailAsync(msg);
