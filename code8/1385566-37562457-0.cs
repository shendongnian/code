    public async void downloadFile(string fileUrl, string fileName)
    {
        var myFolder = await StorageFolder.GetFolderFromPathAsync(Package.Current.InstalledLocation.Path);
        var myFile = await myFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
        var downloader = new BackgroundDownloader();
        var downloadOperation = downloader.CreateDownload(new Uri(fileUrl), myFile);
        var task = Task.Run(async () => await downloadOperation.StartAsync().AsTask());
        if (task.Wait(TimeSpan.FromMilliseconds(1000)))
        {
            // file is downloaded in time
        }
        else {
            // timeout is reached - how to cancel downloadOperation ?????
            downloadOperation.AttachAsync().Cancel();
        }
    }
