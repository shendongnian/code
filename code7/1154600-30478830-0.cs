    foreach(var zipPath in Directory.GetFiles("C:\\Test"))
    {
        using (ZipArchive archive = ZipFile.OpenRead(zipPath))
        {
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                var position = entry.Name.IndexOf(filetosearch , StringComparison.InvariantCultureIgnoreCase);
                if (position > -1)
                {
                    listView1.Items.Add(entry.Name);
                }
            }
        }
    }
