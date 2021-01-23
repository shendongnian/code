    public void Mirror (IMailFolder src, IMailFolder dest)
    {
        // if the folder is selectable, mirror any messages that it contains
        if ((src.Attributes & (FolderAttributes.NoSelect | FolderAttributes.NonExistent)) == 0) {
            src.Open (FolderAccess.ReadOnly);
    
            // we fetch the flags and the internal date so that we can use these values in the APPEND command
            foreach (var item in src.Fetch (0, -1, MessageSummaryItems.Flags | MessageSummaryItems.InternalDate | MessageSummaryItems.UniqueId)) {
                var message = src.GetMessage (item.UniqueId);
    
                dest.Append (message, item.Flags.Value, item.InternalDate.Value); 
            }
        }
    
        // now mirror any subfolders that our current folder has
        foreach (var subfolder in src.GetSubfolders (false)) {
            // if the subfolder is selectable, that means it can contain messages
            var folder = dest.Create (subfolder.Name, (subfolder.Attributes & FolderAttributes.NoSelect) == 0);
    
            Mirror (subfolder, folder);
        }
    }
