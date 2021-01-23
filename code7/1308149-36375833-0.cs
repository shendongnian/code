    using (var smtp = new SmtpClient())
    {
        smtp.DeliveryFormat = SmtpDeliveryFormat.International;
                 
        var message = new MailMessage(
            "my.email@gmail.com",
            "ëçïƒÖ@example.com",
            "UTF8",
            "Is UTF8 supported?");
                  
        smtp.Send(message);
    }
