    void ProcessMail (ImapClient client, FolderNamespaceCollection namespaces)
    {
        string[] names = new string[] { "Verwijderde items", "INBOX" };
    
        foreach (var @namespace in namespaces) {
            // get the root folder in the namespace
            var root = client.GetFolder (@namespace);
    
            // get specific folders:
            foreach (var name in names) {
                try {
                    var folder = root.GetSubfolder (name);
    
                    // Select the folder (if you want to change flags,
                    // use FolderAccess.ReadWrite)
                    folder.Open (FolderAccess.ReadOnly);
    
                    // process mail
                } catch (FolderNotFoundException) {
                }
            }
        }
    }
