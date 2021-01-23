    static void RenameEntry(this ZipArchive archive, string oldName, string newName)
    {
        ZipArchiveEntry oldEntry = archive.GetEntry(oldName),
            newEntry = archive.CreateEntry(newName);
        using (Stream oldStream = oldEntry.Open())
        using (Stream newStream = newEntry.Open())
        {
            oldStream.CopyTo(newStream);
        }
        oldEntry.Delete();
    }
