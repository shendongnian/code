    var msList = new List<MemoryStream>();
    
    foreach (var attachment in message.Attachments)
    {
        var ms = new MemoryStream(attachment.Bytes);
        msList.Add(ms);
    
        var mailAttachment = new Attachment(ms, attachment.FileName);
        mailMessage.Attachments.Add(mailAttachment);
    }
    
    smtp.Send(mailMessage);
    
    foreach (var ms in msList)
    {
        ms.Dispose();
    }
