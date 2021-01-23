    private async Task<Item> UploadDBFile()
    {
        StorageFile DBFile = await ApplicationData.Current.LocalFolder.GetFileAsync("db.sqlite");
    
        var oneDriveClient = await OneDriveClientExtensions.GetAuthenticatedUniversalClient(new[] { "onedrive.appfolder" });
    
        using (var contentStream = await DBFile.OpenStreamForReadAsync())
        {
            return await oneDriveClient.Drive.Special.AppRoot.ItemWithPath("backup.sqlite").Content.Request().PutAsync<Item>(contentStream);
        }
    }
