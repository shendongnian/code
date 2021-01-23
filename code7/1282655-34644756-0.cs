    using (var client = new ImapClient ()) {
        client.Connect ("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
    
        // disable OAuth2 authentication unless you are actually using an access_token
        client.AuthenticationMechanisms.Remove ("XOAUTH2");
    
        // 1. Log in to Gmail
        client.Authenticate ("user@gmail.com", "password");
    
        // 2. Search inbox mail containing a specific keyword in subject or body.
        client.Inbox.Open (FolderAccess.ReadWrite);
    
        var query = SearchQuery.SubjectContains ("123").Or (SearchQuery.BodyContains ("123"));
    
        foreach (var uid in client.Inbox.Search (query)) {
            // 3. Parse the body like you would a text file in C#
    
            // This downloads and parses the full message:
            var message = client.Inbox.GetMessage (uid);
    
            // 4. Download a attachment (test.txt)
    
            // No need to download an attachment because you already
            // downloaded it with GetMessage().
    
            // Here's how you could get the "test.txt" attachment:
            var attachment = message.BodyParts.OfType<MimePart> ()
                .FirstOrDefault (x => x.FileName == "test.txt");
    
            // 5. Delete
    
            // This marks the message as deleted, but does not purge it
            // from the folder.
            client.Inbox.AddFlags (uid, MessageFlags.Deleted, true);
        }
    
        // Purge the deleted messages (if you use Thunderbird, this is aka "Compact Folders")
        client.Inbox.Expunge ();
    
        client.Disconnect (true);
    }
