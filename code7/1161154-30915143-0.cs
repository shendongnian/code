    long abc = 0;
    using (ImapClient client = new ImapClient ()) {
        client.Connect ("abc.com", 143, false);
        client.Authenticate ("abc@abc.com", "password");
    
        client.Inbox.Open (FolderAccess.ReadWrite);
    
        var uids = client.Inbox.Search (SearchQuery.Unseen);
    
        foreach (var uid in uids) {
            var message = inbox.GetMessage (uid);
            var msgFrom = message.From.ToString ();
            var to = message.To.ToString ();
            var subject = message.Subject;
    
            // mark the message as read/seen
            inbox.AddFlags (uid, MessageFlags.Seen, true);
    
            abc = abc + 1;
        }
    }
