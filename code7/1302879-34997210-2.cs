    foreach (FileAttachment attachment in attachments)
    {
        byte[] bytefiles = attachment.ContentBytes;
        string path = @"C:\Top-Level\" + attachment.Name;
        if (!string.IsNullOrEmpty(message.Subject))
        {
            path =  @"C:\Top-Level\" + message.Subject + "." + attachment.ContentType;
        }
        File.WriteAllBytes(path, bytefiles);
    }
