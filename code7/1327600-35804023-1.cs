    void ProcessMail (FolderNamespaceCollection namespaces)
    {
        string[] names = new string[] { "Verwijderde items", "INBOX" };
    
        // client.PersonalNamespaces are the mailboxes that belong to you
        foreach (var @namespace in namespaces) {
            // get the root folder in the namespace
            var root = client.GetFolder (@namespace);
    
            // get the top-level folders in the namespace
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
