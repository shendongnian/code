    MailMessage mail = new MailMessage("MailFrom", "MailTo");
    //Then you could do sth to grab your files like before:
    List<Attachment> attachments = new List<Attachment>();
    foreach(string attachmentPath in docs)
    {
        //Here you provide the path where you saved the pdf
        attachments.Add(new Attachment(attachmentPath);
    }
    mail.Subject = "Here comes the PDF";
    mail.BodyEncoding = Encoding.UTF8;
    mail.Body = "Your message here";
    SmtpClient mailer = new SmtpClient();
    mailer.EnableSsl = true; //Depends on your mailserver if he forces to use SSL
    //(Same procedure as setting up a new Outlook Account...)
    mailer.Host = "mail.gmx.net"; //for example:
    mailer.Port = "587"; //Default SMTP-Port is 25
    
    mailer.UseDefaultCredentials = false;
    //Just your common LoginData for this server
    mailer.Credentials = new NetworkCredential("EmailUserName", "EmailPassword");
  
    mailer.Send(mail);
