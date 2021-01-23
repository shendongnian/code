    MailMessage mail = new MailMessage();
    SmtpClient SmtpServer = new SmtpClient();
    mail.To.Add(email);
    mail.From = new MailAddress("mail@domain.com");
    mail.Subject = subject;
    mail.IsBodyHtml = true;
    mail.Body = message;
    SmtpServer.Host = "smtpserver";
    SmtpServer.Port = 25;
    SmtpServer.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
    try {
        SmtpServer.Send(mail);
    }
    catch (Exception ex) {
        Debug.WriteLine("Exception Message: " + ex.Message);
        if (ex.InnerException != null)
            Debug.WriteLine("Exception Inner:   " + ex.InnerException);
    }
