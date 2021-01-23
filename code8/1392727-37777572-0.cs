    public async static Task<IStorageFolder> GetFolderPathFromTheUser()
    {
        FolderPicker folderPicker = new FolderPicker();
        folderPicker.ViewMode = PickerViewMode.Thumbnail;
        folderPicker.FileTypeFilter.Add(".");
        var folder = await folderPicker.PickSingleFolderAsync();
        return folder;
    }
    public async static Task<bool> IsContainImageFiles(IStorageFolder folder)
    {
        IReadOnlyList<StorageFile> temp= await folder.GetFilesAsync();
        foreach (StorageFile sf in temp)   
        {
            if (sf.ContentType == "jpg")
                return true;
        }
        return false;
    }
