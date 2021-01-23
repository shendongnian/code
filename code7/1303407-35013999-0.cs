    using (var client = new ImapClient(hostname, true))
    {
        if (client.Connect( /* optional, use parameters here */) && client.Login(login, pass))
        {
            foreach (Folder myfolder in client.Folders)
            {
                using (myfolder)
                {
                    foreach (var message in myfolder.Search("ALL"))
                    {
                        using (message)
                        {
                            var attachments = message.Attachments;
                            using (attachments)
                            {
                                if (attachments.Any() && !Directory.Exists(folder + @"\" + login))
                                {
                                    Directory.CreateDirectory(folder + @"\" + login);
                                }
                                foreach (var attachment in attachments)
                                {
                                    using (attachment)
                                    {
                                        attachment.Download();
                                        attachment.Save(folder + @"\" + login);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        client.Disconnect();
    }
