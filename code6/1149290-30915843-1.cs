    using (var client = new ImapClient ()) {
        client.Connect ("imap-mail.outlook.com", 993, true);
        client.Authenticate ("name@hotmail.com", "password");
    
        client.Inbox.Open (FolderAccess.ReadWrite);
    
        for (int i = 0; i < client.Inbox.Count; i++) {
            var message = client.Inbox.GetMessage (i);
            var html = message.HtmlBody;
            var text = message.TextBody;
    
            // mark the message as read
            client.Inbox.AddFlags (id, MessageFlags.Seen, true);
        }
    
        client.Disconnect (true);
    }
