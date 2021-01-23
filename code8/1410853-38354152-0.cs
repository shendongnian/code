    FileSystemWatcher watcher = new FileSystemWatcher();
        watcher.Path = Freconfig.GetSamplesFolder();
        watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
           | NotifyFilters.FileName | NotifyFilters.DirectoryName;
        watcher.Filter = "*.jpg";
        // Add event handlers.
        //watcher.Changed += new FileSystemEventHandler(OnChanged);
        watcher.Created += new FileSystemEventHandler(OnChanged);
        //watcher.Deleted += new FileSystemEventHandler(OnChanged);
        //watcher.Renamed += new RenamedEventHandler(OnRenamed);
        // Begin watching.
        watcher.EnableRaisingEvents = true;
