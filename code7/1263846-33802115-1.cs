    string mailServer = "smtp-mail.outlook.com";
    
    SmtpClient client = new SmtpClient(mailServer, 25); // or 587
    client.DeliveryMethod = SmtpDeliveryMethod.Network;
    client.EnableSsl = true;
    client.UseDefaultCredentials = false;
    
    var AuthenticationDetails = new NetworkCredential("user@domain.com", "password");
    client.Credentials = AuthenticationDetails;
    
    using (MailMessage message = new MailMessage("user@domain.com", recipient))
    {
        message.IsBodyHtml = true;
        message.Body = htmlString;
        message.Subject = "Test Email";
    
        client.Send(message);
    }
