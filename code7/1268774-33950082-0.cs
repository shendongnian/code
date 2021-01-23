    string[] pathes = /* ... */;
    foreach (var path in pathes)
    {
        mailMessage.Attachments.Add(new System.Net.Mail.Attachment(path));
    }
