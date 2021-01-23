    var message = new MailMessage();
    
    using(var client1 = new SmtpClient())
    {
        client1.Send(message);
    }
    ...
    using(var client2 = new SmtpClient())
    {
        client2.Send(message);
    }
