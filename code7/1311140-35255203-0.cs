    var attachments = files
        .Where(f => f.Exists)
        .Select(f => new
        {
            Path = f.FullName,
            ContentName = Path.GetFileNameWithoutExtension(f.FullName)
        });
    foreach (var attachmentInfo in attachments)
    {
        message.Attachments.Add(
            new Attachment(attachmentInfo.Path) { Name = attachmentInfo.ContentName });
    }
