    var messages = client.Inbox.Fetch (0, -1, MessageSummaryItems.Full | MessageSummaryItems.UniqueId);
    int unnamed = 0;
    
    foreach (var message in messages) {
        var multipart = message.Body as BodyPartMultipart;
        var basic = message.Body as BodyPartBasic;
    
        if (multipart != null) {
            foreach (var attachment in multipart.BodyParts.OfType<BodyPartBasic> ().Where (x => x.IsAttachment)) {
                var mime = (MimePart) client.Inbox.GetBodyPart (message.UniqueId.Value, attachment);
                var fileName = mime.FileName;
    
                if (string.IsNullOrEmpty (fileName))
                    fileName = string.Format ("unnamed-{0}", ++unnamed);
    
                using (var stream = File.Create (fileName))
                    mime.ContentObject.DecodeTo (stream);
            }
        } else if (basic != null && basic.IsAttachment) {
            var mime = (MimePart) client.Inbox.GetBodyPart (message.UniqueId.Value, basic);
            var fileName = mime.FileName;
    
            if (string.IsNullOrEmpty (fileName))
                fileName = string.Format ("unnamed-{0}", ++unnamed);
    
            using (var stream = File.Create (fileName))
                mime.ContentObject.DecodeTo (stream);
        }
    }
