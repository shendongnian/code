    MailMessage message = new System.Net.Mail.MailMessage(); 
    string fromEmail = "youremailaddress@xyz.com";
    string password = "yourPassword";
    string toEmail = "recipientemailaddress@abc.com";
    message.From = new MailAddress(fromEmail);
    message.To.Add(toEmail);
    message.Subject = "Using the new SMTP client.";
    message.Body = "Using this new feature, you can send an e-mail message from an application very easily.";
    message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
    
    using(SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
    {
        smtpClient.EnableSsl = true;
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new NetworkCredential(fromEmail, password);
    
        smtpClient.Send(message.From.ToString(), message.To.ToString(), message.Subject, message.Body);   
    }
     
