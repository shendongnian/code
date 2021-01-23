    var messages = client.Inbox.Fetch (0, -1, MessageSummaryItems.Full | MessageSummaryItems.BodyStructure | MessageSummaryItems.UniqueId);
    int unnamed = 0;
    
    foreach (var message in messages) {
        foreach (var attachment in message.Attachments) {
            var mime = (MimePart) client.Inbox.GetBodyPart (message.UniqueId.Value, attachment);
            var fileName = mime.FileName;
    
            if (string.IsNullOrEmpty (fileName))
                fileName = string.Format ("unnamed-{0}", ++unnamed);
    
            using (var stream = File.Create (fileName))
                mime.ContentObject.DecodeTo (stream);
        }
    }
