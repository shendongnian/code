    using (var client = new ImapClient ()) {
        client.Connect ("imap.gmail.com", 993, true);
        client.Authenticate ("username", "password");
    
        client.Inbox.Open (FolderAccess.ReadWrite);
    
        var summaries = client.Fetch (0, -1, MessageSummaryItems.UniqueId |
            MessageSummaryItems.BodyStructure | // metadata for mime parts
            MessageSummaryItems.Envelope);      // metadata for messages
        foreach (var summary in summaries) {
            // Each summary item will have the UniqueId, Body and Envelope properties
            // filled in (since that's what we asked for).
            var uid = summary.UniqueId.Value;
            Console.WriteLine ("The UID of the message is: {0}", uid);
            Console.WriteLine ("The Message-Id is: {0}", summary.Envelope.MessageId);
            Console.WriteLine ("The Subject is: {0}", summary.Envelope.Subject);
            // Note: there are many more properties, but you get the idea...
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
                        Console.WriteLine ("The size of this attachment is: {0} bytes", basic.Octets);
                        Console.WriteLine ("The file name is: {0}", basic.FileName);
                        // If you want to download just this attachment, you can download it like this:
                        var attachment = client.Inbox.GetBodyPart (uid, basic);
                    }
                }
            }
        }
    
        client.Disconnect (true);
    }
