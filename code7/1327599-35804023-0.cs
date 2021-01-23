    try {
        using (var client = new ImapClient ()) {
            client.Connect (server, 993, true); // I assume you are connecting via SSL
            client.Authenticate (username, password);
    
            string[] names = new string[] { "Verwijderde items", "INBOX" };
    
            // client.PersonalNamespaces are the mailboxes that belong to you
            foreach (var personalNamespace in client.PersonalNamespaces) {
                // get the root folder in your personal namespace
                // (there's always at least 1 personal namespace)
                var root = client.GetFolder (personalNamespace);
    
                // get the top-level folders in your personal namespace
                foreach (var folder in root.GetSubfolders ()) {
                    foreach (var name in names) {
                        if (folder.Name == name) {
                            // Select the folder (if you want to change flags,
                            // use FolderAccess.ReadWrite)
                            folder.Open (FolderAccess.ReadOnly);
    
                            // process mail
                        }
                    }
                }
            }
    
            // client.SharedNamespaces are the shared mailboxes
            foreach (var sharedNamespace in client.SharedNamespaces) {
                var root = client.GetFolder (sharedNamespace);
    
                // get the top-level folders in your shared namespace
                foreach (var folder in root.GetSubfolders ()) {
                    foreach (var name in names) {
                        if (folder.Name == name) {
                            // Select the folder (if you want to change flags,
                            // use FolderAccess.ReadWrite)
                            folder.Open (FolderAccess.ReadOnly);
    
                            // process mail
                        }
                    }
                }
            }
        }
    } catch (Exception ex) {
        Console.WriteLine ("Imap not Connected");
        Console.WriteLine (ex.Message);
        Console.WriteLine (ex.StackTrace);
    }
