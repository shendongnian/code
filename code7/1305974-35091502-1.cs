    string fileName = string.Format("OrderConfirmation-{0}", DateTime.Now); 
    MailMessage message = new MailMessage(from, to);
    message.Subject = subject;
    message.Body = body;
    
    MemoryStream stream = new MemoryStream(fileBytes);    
    stream.Position = 0; 
    Attachment attachment = new Attachment(stream, fileName, MediaTypeNames.Application.Octet);
    message.Attachments.Add(attachment);
    SmtpClient mailServer = new SmtpClient(example.stmphost.com);
    mailserver.Send(message);
    message.Dispose(); 
