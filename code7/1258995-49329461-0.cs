    SmtpClient smtpServer = new SmtpClient(smtpServerName);
    smtpServer.Port = 25;
    smtpServer.Credentials = new System.Net.NetworkCredential(userName, password);
    //smtpServer.EnableSsl = true;
    MailMessage smtpEmail = new MailMessage();
    string messageBodyImage = @"<img width=1200 id=""MyContent"" src=""cid:{0}"">";
     toAddressList = toAddress.Split(';');
    foreach (string toEmail in toAddressList)
        smtpEmail.To.Add(toEmail);
    
    smtpEmail.From = new MailAddress(fromAddress);
    smtpEmail.Body = messageBody;
    smtpEmail.Subject = subject;
    foreach (string format in fileExtension)
     {
    
        switch (format)
         {       
        case "PNG": 
    	smtpEmail.IsBodyHtml = true;
    	smtpEmail.AlternateViews.Add(GetEmbeddedImage(reportByteStream, messageBodyImage, format)); 
    	break;
        case "CSV":      
    	smtpEmail.Attachments.Add(new System.Net.Mail.Attachment(new MemoryStream(myStream[format][0]), "MyReport." + format, "text/csv"));     break;
        case "XLS": 
    	smtpEmail.Attachments.Add(new System.Net.Mail.Attachment(new MemoryStream(myStream[format][0]), "MyReport." + format, "application/vnd.ms-excel"));
    	break;
        default: // For PDF
    	smtpEmail.Attachments.Add(new System.Net.Mail.Attachment(new MemoryStream(myStream[format][0]), "MyReport." + format, MediaTypeNames.Application.Pdf));
    	break;
        }
    }
    
