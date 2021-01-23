        SmtpClient client= new SmtpClient(server, port);
        
        client.Credentials = new System.Net.NetworkCredential(username, password);
        client.UseDefaultCredentials = true;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.EnableSsl = true;
      
        MailMessage email = new MailMessage(from, to, subject, body);
    
        email.Attachments.Add(new Attachment(GlobalVariables.attachedFilePath));
        email.Attachments.Add(new Attachment(GlobalVariables.formsAndTemplatesPath[0]));
        email.Attachments.Add(new Attachment(GlobalVariables.formsAndTemplatesPath[1]));
        email.Attachments.Add(new Attachment(GlobalVariables.formsAndTemplatesPath[2]));
    
        client.Send(email);
