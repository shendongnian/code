    public Task LoadFile()
    {
        Task<Byte[]> bytesTask = wc.DownloadDataTaskAsync(new Uri(string.Format("{0}/{1}", Settings1.Default.WebPhotosLocation, Path.GetFileName(f.FullName))), filePath);
        var success = bytesTask.ContinueWith((prev) =>
            {
                System.IO.File.WriteAllBytes(prev.Result); 
            },
            TaskContinuationOptions.OnlyOnRanToCompletion);
        
        var failure = bytesTask.ContinueWith(prev =>
            {
                MessageBox.Show //...
            },
            TaskContinuationOptions.OnlyOnFaulted);
        return Task.WhenAny(success, failure);
    }
