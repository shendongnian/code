    public void DownloadAllAttachments()
    {
        using (var client = new ImapClient(hostname, true))
        {
            if (!client.Connect( /* optional, use parameters here */) || !client.Login(login, pass))
                return;
            string path = string.Intern(Path.Combine(folder, login));
            foreach (Folder myfolder in client.Folders)
            {
                foreach (var message in myfolder.Search())
                {
                    var attachments = message.Attachments;
                    if (attachments.Length > 0 && !Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    foreach (var attachment in attachments)
                    {
                        attachment.Download();
                        attachment.Save(path);
                    }
                }
            }
        }
    }
