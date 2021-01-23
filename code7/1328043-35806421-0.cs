    var mimeMessage = MimeMessage.Load(@"test.eml");
    var attachments = mimeMessage.Attachments.ToList();
    
    foreach (var attachment in attachments.OfType<MimePart> ())
    {
        using (var memory = new MemoryStream ())
        {
            attachment.ContentObject.DecodeTo (memory);
            var bytes = memory.ToArray ();
        }
    }
