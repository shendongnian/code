    public void MyFileWatcher(string path)
    {
        FileSystemWatcher watcher = new FileSystemWatcher();
        watcher.Path = path;
        watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite 
           | NotifyFilters.FileName | NotifyFilters.DirectoryName;
        watcher.Filter = "myFile.txt";
        watcher.Changed += new FileSystemEventHandler(OnChanged);    
        watcher.EnableRaisingEvents = true;
    }
    
    private static void OnChanged(object source, FileSystemEventArgs e)
    {
       Console.WriteLine(e.FullPath + " " + e.ChangeType);
    }
