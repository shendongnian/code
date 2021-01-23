    private async Task Init()
    {
        var storageFolder = ApplicationData.Current.LocalFolder;
        var monitor = storageFolder.CreateFileQuery();
        monitor.ContentsChanged += MonitorContentsChanged;
        var files = await monitor.GetFilesAsync();
    }
    private void MonitorContentsChanged(IStorageQueryResultBase sender, object args)
    {
        // react to the file change - should mean the background task completed
    }
