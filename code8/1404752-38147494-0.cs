    var contentType = new System.Net.Mime.ContentType(System.Net.Mime.MediaTypeNames.Application.Pdf);
    var attachmentFile = PdfById(id);
    var attachmentStream = new MemoryStream((attachmentFile as FileContentResult).FileContents);
    var attachmentTitle = (attachmentFile as FileContentResult).FileDownloadName;
    var message = new MailMessage();
    message.Attachments.Add(new Attachment(attachmentStream, attachmentTitle, contentType.ToString()));
