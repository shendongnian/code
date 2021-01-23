    protected void Application_Start()
    {
        // Other initializations ...
        // ....
        var watcher = new FileSystemWatcher();
        //Set the folder to watch
        watcher.Path = Server.MapPath("~/Config");
        watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite;
        //Set a filter to watch
        watcher.Filter = "*.json";
        watcher.Changed += watcher_Changed;
        // Begin watching.
        watcher.EnableRaisingEvents = true;
    }
    void watcher_Changed(object sender, FileSystemEventArgs e)
    {
        //Restart application here
    }
