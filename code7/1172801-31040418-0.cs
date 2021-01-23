    string message ="my255CharText";
    
    MailMessage emailMsg = new MailMessage();
    emailMsg.To.Add("email@destination.com);
    emailMsg.Subject = "my Subject";
    emailMsg.From = new MailAddress("email@source.com");
    emailMsg.BodyEncoding = System.Text.Encoding.ASCII;
    emailMsg.IsBodyHtml = false;
    
    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(System.Text.Encoding.ASCII.GetBytes(message))
    {
        Attachment data = new Attachment(ms, MediaTypeNames.Text.Plain);
    
        emailMsg.Attachments.Add(data);
        ContentDisposition dispositon = data.ContentDisposition;
        dispositon.Inline=true;
        SmtpClient smtp = new SmtpClient("SMTP_SERVER");
        smtp.Send(emailMsg);
    }
