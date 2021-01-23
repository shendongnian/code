    string watchDir = Application.StartupPath;
    watcher = new FileSystemWatcher(watchDir, "*.jpg");
    watcher.NotifyFilter |= NotifyFilters.Size;
    watcher.Created += new FileSystemEventHandler(watcher_Created);
    watcher.EnableRaisingEvents = true;
    protected void watcher_Created(object sender, FileSystemEventArgs e)
    {
        string changeType = e.ChangeType.ToString();
        if (changeType != "Created")
        {
            return;
        }
        // file is created, wait for IsFileReady or whatever You need
    }
