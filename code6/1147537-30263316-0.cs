    private async Task InitFilesAsync()
    {
        await WalkFolderAsync(KnownFolders.MediaServerDevices);
        foreach (var f in fileList)
        {
            this.lbxFiles.Items.Add(f);
        }
    }
    private async Task WalkFolderAsync(StorageFolder parent)
    {   
        var items = await parent.GetItemsAsync();
        foreach(var item in items)
        {
            if (item.IsOfType(StorageItemTypes.Folder))
            {
                await WalkFolderAsync((StorageFolder)item);
            }
            else if (item.IsOfType(StorageItemTypes.File))
            {
                fileList.Add((StorageFile)item);
            }
        }
    }
