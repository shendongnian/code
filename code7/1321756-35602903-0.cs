    ...
    FileSystemWatcher watcher = new FileSystemWatcher();
    watcher.Path = @"D:\SomeTestDirectory";
    watcher.Filter = "*.*";
    watcher.NotifyFilter = NotifyFilters.FileName; // Trigger only on events associated with the filename
    watcher.Created += new FileSystemEventHandler(OnChanged);
    watcher.EnableRaisingEvents = true;            // Starts the "watching"
    ...
    private static void OnChanged(object source, FileSystemEventArgs e)
    {
       // Do whatever you want here, e.g. rename the file.
       Console.WriteLine("File: " +  e.FullPath + " " + e.ChangeType);
    }
