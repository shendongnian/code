    using (var client = new ImapClient ()) {
        client.Connect ("imap.gmail.com", 993, true);
        client.Authenticate ("username", "password");
    
        client.Inbox.Open (FolderAccess.ReadWrite);
    
        var summaries = client.Fetch (0, -1, MessageSummaryItems.UniqueId | MessageSummaryItems.BodyStructure);
        foreach (var summary in summaries) {
            // Each summary item will have the UniqueId and the Body properties
            // filled in (since that's what we asked for).
            // Since you want to know the metadata for each attachment, you can
            // now walk the MIME structure via the Body property and get
            // whatever details you want to get about each MIME part.
            var multipart = summary.Body as BodyPartMultipart;
            if (multipart != null) {
                foreach (var part in multipart.BodyParts) {
                    var basic = part as BodyPartBasic;
    
                    if (basic != null && basic.IsAttachment) {
                        // See http://www.mimekit.net/docs/html/Properties_T_MailKit_BodyPartBasic.htm
                        // for more details on what properties are available.
                    }
                }
            }
        }
    
        client.Disconnect (true);
    }
