    SmtpClient smtpClient = new SmtpClient(WebMail.SmtpServer);
    MailMessage email = new MailMessage(...);
    var stream = new System.IO.MemoryStream(pdfBytes);
    email .Attachments.Add(new Attachment(stream, "invoice.pdf"));
    smtpClient.Send(email);
