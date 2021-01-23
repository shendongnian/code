    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
    SmtpClient SmtpServer = new SmtpClient("servername"); 
    mail.From = new MailAddress(strFromAddress);
    mail.To.Add(strToAddress);
    mail.Subject = strSubject;
    mail.Body = strMessage;
    SmtpServer.Send(mail);
