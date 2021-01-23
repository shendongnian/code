    foreach(var msg in messages)
    {
        foreach (var attachment in msg.Attachments)
        {
            using (var fileStream = File.Create("C:\\Folder"))
            {
                attachment.ContentStream.Seek(0, SeekOrigin.Begin);
                attachment.ContentStream.CopyTo(fileStream);
            }
        }
    }
