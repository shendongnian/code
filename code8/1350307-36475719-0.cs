    string folder = Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";
    using (var watcher = new FileSystemWatcher(folder)) {
        // wait for new file to be created
        var result = watcher.WaitForChanged(WatcherChangeTypes.Created, 5000);
        if (result.TimedOut)
            throw new WebDriverTimeoutException("Dowmload failed");
        Console.WriteLine("Download started for : " + Path.Combine(folder, result.Name));
        // wait for the temporary file to be deleted
        var result2 = watcher.WaitForChanged(WatcherChangeTypes.Deleted, 10000);
        if (result2.TimedOut)
            throw new WebDriverTimeoutException("Dowmload failed");
        Console.WriteLine("Download finished for : " + Path.Combine(folder, result.Name));
    }
