    using (var stream = new MemoryStream())
    using (var writer = new StreamWriter(stream))    
    using (var mailClient = new SmtpClient("localhost", 25))
    using (var message = new MailMessage("me@example.com", "you@example.com", "Just testing", "See attachment..."))
    {
        writer.Flush();
        stream.Position = 0;     
    
        message.Attachments.Add(new Attachment(stream, "filename.csv", "text/csv"));
    
        mailClient.Send(message);
    }
