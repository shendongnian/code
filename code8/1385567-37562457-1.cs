    public async void downloadFile(string fileUrl, string fileName)
    {
        var myFolder = await StorageFolder.GetFolderFromPathAsync(Package.Current.InstalledLocation.Path);
        var myFile = await myFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
        var downloader = new BackgroundDownloader();
        var downloadOperation = downloader.CreateDownload(new Uri(fileUrl), myFile);
        // Define the cancellation token.
        CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken token = cts.Token;
        cts.CancelAfter(1000);
        try
        {
            // Pass the token to the task that listens for cancellation.
            await downloadOperation.StartAsync().AsTask(token);
            // file is downloaded in time
        }
        catch (TaskCanceledException)
        {
            // timeout is reached, downloadOperation is cancled
        }
        finally
        {
            // Releases all resources of cts
            cts.Dispose();
        }
    }
