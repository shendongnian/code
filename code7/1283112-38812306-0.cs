    private ObservableCollection<BitmapImage> _items; // your collection which is bound to ListView
    
    // deleting images of removed items
    private async Task DeleteUnusedImages()
    {
        try
        {
            var folder = await ApplicationData.Current.LocalFolder.GetFolderAsync("folderName");
            var files = await folder.GetFilesAsync(); // getting all files inside that folder
    
            foreach (var file in files)
            {
                // checking if the image still exist in the collection or got removed
                // if removed then remove it from the local folder too.
                if (!_items.Any(i => i.ImageName.Contains(file.Name)))
                {
                    await file.DeleteAsync(StorageDeleteOption.PermanentDelete);
                }
            }
        }
        catch (Exception ex)
        {
    
        }
    }
