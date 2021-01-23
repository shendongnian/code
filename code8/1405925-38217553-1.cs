    private async Task DownloadDBFile()
    {
        var oneDriveClient = await OneDriveClientExtensions.GetAuthenticatedUniversalClient(new[] { "onedrive.appfolder" });
    
        using (var contentStream = await oneDriveClient.Drive.Special.AppRoot.ItemWithPath("backup.sqlite").Content.Request().GetAsync())
        {
            StorageFile downloadedFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("DownloadedDB.sqlite",
    CreationCollisionOption.ReplaceExisting);
            using (var writerStream = await downloadedFile.OpenStreamForWriteAsync())
            {
                contentStream.CopyTo(writerStream);
            }
        };
    }
