    public async static Task<string> GetFolderPathFromTheUser()
    {
        FolderPicker folderPicker = new FolderPicker();
        folderPicker.ViewMode = PickerViewMode.Thumbnail;
        folderPicker.FileTypeFilter.Add(".");
        var folder = await folderPicker.PickSingleFolderAsync();
        return FutureAccessList.Add(folder); 
    }
    public async static Task<bool> IsContainImageFiles(string accessToken)
    {
        IStorageFolder folder = await FutureAccessList.GetFolderAsync(accessToken);
        IReadOnlyList<StorageFile> temp= await folder.GetFilesAsync();
        foreach (StorageFile sf in temp)   
        {
            if (sf.ContentType == "jpg")
                return true;
        }
        return false;
    }
