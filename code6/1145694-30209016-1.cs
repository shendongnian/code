    MailMessage mail_client = new MailMessage();
     int index = 0
      foreach (var email in chkbox)
       {
       mail_client.To.Add(chkbox[index]);  
        index++;
       }
    
    mail_client.From = new MailAddress("");
    mail_client.Subject = subject;
    mail_client.IsBodyHtml = true;
    mail_client.Body = body;
    
    smtp.Host = "";
    smtp.Port = ;
    smtp.UseDefaultCredentials = true;
    smtp.Send(mail_client);
