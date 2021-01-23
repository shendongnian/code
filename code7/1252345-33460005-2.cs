    private async Task<string> WatchDirectoryAsync()
    {
        using (FileSystemWatcher watcher = new FileSystemWatcher())
        {
            TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();
            watcher.Path = userVideosDirectory;
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size;
            watcher.Filter = "*.mp4";
            watcher.Changed += (sender, e) => tcs.SetResult(e.FullPath);
            watcher.EnableRaisingEvents = true;
            return await tcs.Task;
        }
    }
    // You can get rid of the OnChanged() method altogether
    private async Task WaitForUnlockedFileAsync(string fileName)
    {
        while (true)
        {
            try
            {
                using (IDisposable stream = File.Open(fileName, FileMode.OpenOrCreate,
                    FileAccess.ReadWrite, FileShare.None))
                { /* on success, immediately dispose object */ }
                break;
            }
            catch (IOException)
            {
                // ignore exception
                // NOTE: for best results, consider checking the hresult value of
                // the exception, to ensure that you are only ignoring the access violation
                // exception you're expecting, rather than other exceptions, like
                // FileNotFoundException, etc. which could result in a hung process
            }
            // You might want to consider a longer delay...maybe on the order of
            // a second or two at least.
            await Task.Delay(100);
        }
    }
