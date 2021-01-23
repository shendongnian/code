    SmtpClient ss = new SmtpClient();
    ss.Host = "smtpout.secureserver.net";
    ss.Port = 80;
    ss.Timeout = 10000;
    ss.DeliveryMethod = SmtpDeliveryMethod.Network;
    ss.UseDefaultCredentials = false;
    ss.EnableSsl = false;
    ss.Credentials = new NetworkCredential("abc@yourdomain.com", "password");
    
    MailMessage mailMsg = new MailMessage("abc@yourdomain.com", email, "subject here", "my body");
    mailMsg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
    ss.Send(mailMsg);
    
