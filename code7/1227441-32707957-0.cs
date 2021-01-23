    System.Timers.Timer eventTimer = new System.Timers.Timer(); 
    List<string> AlbumList = new List<string>();
    private void watcher_Created(object sender, FileSystemEventArgs e)
    {    
        if (Directory.Exists(e.FullPath))
        {
            AlbumList.Add(e.FullPath);
        }
        if (File.Exists(e.FullPath))
        {
            eventTimer.Stop();
            FileInfo newTrack = new FileInfo(e.FullPath);
            while (IsFileLocked(newTrack))
            {
                // File is locked. Do Nothing..
            }
            eventTimer.Start();              
        }
    }
    private void eventTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        List<string> ItemToRemove = new List<string>();
        foreach (var item in AlbumList)
        {            
            DirectoryInfo di = new DirectoryInfo(item);
            AlbumSearch newAlbum = new AlbumSearch(di);
            if (DoSomethingMethod(newAlbum))
            {
                ItemToRemove.Add(item);
            }
            else
            {
                // why did it fail
            }
        }
        foreach (var path in ItemToRemove)
        {
            AlbumList.Remove(path);
        }
    }
    private bool DoSomethingMethod(AlbumSearch as)
    {
        // Do stuff here 
        return true;
    }
