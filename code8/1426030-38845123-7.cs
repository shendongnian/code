    public void PopulateTree(string path)
    {
        Tag = path;
        using (NtfsUsnJournal ntfs = new NtfsUsnJournal(new DriveInfo(path)))
        {
            List<NtfsUsnJournal.UsnEntry> folders;
            ntfs.GetNtfsVolumeFolders(out folders);
            Func<NtfsUsnJournal.UsnEntry, ulong> getId = (x => x.FileReferenceNumber);
            Func<NtfsUsnJournal.UsnEntry, ulong?> getParentId = (x => x.ParentFileReferenceNumber);
            Func<NtfsUsnJournal.UsnEntry, string> getDisplayName = (x => x.Name);
            LoadItems(folders, getId, getParentId, getDisplayName);
        }
    }
