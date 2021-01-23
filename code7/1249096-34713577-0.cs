    using (var client = new ImapClient ()) {
        client.Connect ("imap.gmail.com", 993, true);
        
        // since we're not using an OAuth2 token, remove it from the set
        // of possible authentication mechanisms to try:
        client.AuthenticationMechanisms.Remove ("XOAUTH2");
    
        client.Authenticate ("charlie@gmail.com", "*****");
    
        // SELECT the INBOX folder
        client.Inbox.Open (FolderAccess.ReadWrite);
    
        foreach (var uid in client.Inbox.Search (SearchQuery.NotSeen)) {
            var message = client.Inbox.GetMessage (uid);
    
            // at this point, 'message' is a MIME DOM that you can walk
            // over to get the particular MIME-part that you want. For
            // example, we could get a body part with a filename of
            // "test.txt" using LINQ like this:
            var attachment = message.BodyParts.OfType<MimePart> ()
                .FirstOrDefault (x => x.FileName == "test.txt");
    
            // decode the content to a MemoryStream:
            using (var memory = new MemoryStream ()) {
                attachment.ContentObject.DecodeTo (memory);
            }
    
            // since the attachment is probably a TextPart
            // (based on the file extension above), we can actually
            // use a simpler approach:
            var textPart = attachment as TextPart;
            if (textPart != null) {
                // decode the content and convert into a 'string'
                var text = textPart.Text;
            }
        }
        client.Disconnect (true);
    }
