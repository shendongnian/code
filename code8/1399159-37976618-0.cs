    MailMessage mailMessage = new MailMessage();
    MailAddress fromAddress = new MailAddress("myEmail@gmail.com"); //sender email address 
    mailMessage.From = fromAddress;
    mailMessage.To.Add("myEmail@gmail.com");    //receiver email address               
    mailMessage.Body = command.Message;
    mailMessage.IsBodyHtml = true;
    mailMessage.DisplayName = command.email; //This line is added
    mailMessage.Subject = "Contact Us";
    SmtpClient smtpClient = new SmtpClient();
    smtpClient.Host = "smtp.gmail.com";
    smtpClient.Port = 587;
    smtpClient.EnableSsl = true;
    smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
    smtpClient.Credentials = new System.Net.NetworkCredential("myEmail@gmail.com", "password");
    smtpClient.Send(mailMessage);
