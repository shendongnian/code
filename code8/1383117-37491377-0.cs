    foreach (Item item in
        versionControl.GetItems(serverPath, VersionSpec.Latest, RecursionType.Full, DeletedState.NonDeleted, ItemType.Any, true).Items)
    {
        string target = Path.Combine(downloadPath, item.ServerItem.Substring(2));
        if (item.ItemType == ItemType.Folder && !Directory.Exists(target))
        {
            Directory.CreateDirectory(target);
        }
        else if (item.ItemType == ItemType.File)
        {
            item.DownloadFile(target);
        }
    }  
  
