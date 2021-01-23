    public void DownloadAllAttachments()
    {
        using (var client = new ImapClient(hostname, true))
        {
            if (!client.Connect( /* optional, use parameters here */) || !client.Login(login, pass))
                return;
            string path = string.Intern(Path.Combine(folder, login));
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            foreach (Folder myfolder in client.Folders)
            {
                foreach (var message in myfolder.Search())
                {
                    foreach (var attachment in message.Attachments)
                    {
                        attachment.Download();
                        attachment.Save(path);
                    }
                }
            }
        }
    }
