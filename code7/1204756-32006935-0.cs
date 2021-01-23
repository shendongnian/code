    watcher.Changed += new FileSystemEventHandler(OnChanged);//<-- call OnChanged when the contents changed
    watcher.Created += new FileSystemEventHandler(OnChanged);//<-- call OnChanged when new files are created
    watcher.Deleted += new FileSystemEventHandler(OnChanged);//<-- call OnChanged when any file is deleted
    watcher.Renamed += new RenamedEventHandler(OnRenamed);//<-- call OnChanged when any file is renamed
    private static void OnChanged(object source, FileSystemEventArgs e)
        {
           // Define your method here
        }
