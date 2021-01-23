    FileSystemWatcher watcher = new FileSystemWatcher();
    watcher.Path = Folder;
    watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | 
                   NotifyFilters.DirectoryName | NotifyFilters.FileName;
    watcher.Changed += new FileSystemEventHandler(OnChanged);
    watcher.Created += new FileSystemEventHandler(OnCreated);
    watcher.Deleted += new FileSystemEventHandler(OnChanged);
    watcher.Renamed += new RenamedEventHandler(OnRenamed);
    watcher.EnableRaisingEvents = true;
