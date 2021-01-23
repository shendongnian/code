    SmtpClient client = new SmtpClient(emailsrvr, emailport);
    smtpclient.Credentials = //Credentials from server
    MailMessage email = new MailMessage();
    
    /*
     Skipping lines
    */
    smtpClient.SendAsync(email, null);
