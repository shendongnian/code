    using (ZipArchive archive = ZipFile.OpenRead(ZipFilePath))
    {
        List<ZipArchiveEntry> listOfZipFolders = new List<ZipArchiveEntry>();
        foreach (ZipArchiveEntry entry in archive.Entries)
        {
            if (entry.FullName.EndsWith("/"))
                listOfZipFolders.Add(entry);
        }
        int foldersCount = listOfZipFolders.Count;
    }
