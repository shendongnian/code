    foreach (Folder myfolder in folders)
    {
        var messages = client.Folders[i].Search("ALL");
        i++;
        foreach (var message in messages)
        {
            var attachments = message.Attachments;
            if (attachments.Count() > 0)
                if (!Directory.Exists(folder + @"\" + login))
                {
                    DirectoryInfo di = Directory.CreateDirectory(folder + @"\" + login);// Try to create the directory.
                }
            foreach (var attachment in attachments)
            {
                attachment.Download();
                attachment.Save(folder + @"\" + login);
            }
            attachments = null;
        }
        messages = null;
        // performance killer
        GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
        GC.Collect(2);
        GC.WaitForPendingFinalizers();
        GC.Collect(2); 
    } 
