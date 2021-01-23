    //This method copies selected image into local data folder and returns new file's name.
    public async Task<string> CopySelectedImage()
    {
        FileOpenPicker openPicker = new FileOpenPicker();
        openPicker.ViewMode = PickerViewMode.Thumbnail;
        openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
    
        openPicker.FileTypeFilter.Clear();
        openPicker.FileTypeFilter.Add(".bmp");
        openPicker.FileTypeFilter.Add(".jpg");
        openPicker.FileTypeFilter.Add(".jpeg");
        openPicker.FileTypeFilter.Add(".png");
    
        var file = await openPicker.PickSingleFileAsync();
    
        if (file != null)
        {
            var localFolder = ApplicationData.Current.LocalFolder;
            var newCopy = await file.CopyAsync(localFolder, file.Name, NameCollisionOption.GenerateUniqueName);
            return newCopy.Name;
        }
        else
        {
            return null;
        }
    }
