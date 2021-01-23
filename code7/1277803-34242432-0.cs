     public static Task WhenFileCreated(string path)
    {
        if (File.Exists(path))
            return Task.FromResult(true);
    
        var tcs = new TaskCompletionSource<bool>();
        FileSystemWatcher watcher = new FileSystemWatcher(Path.GetDirectoryName(path));
    
        FileSystemEventHandler createdHandler = null;
        RenamedEventHandler renamedHandler = null;
        createdHandler = (s, e) =>
        {
            if (e.Name == Path.GetFileName(path))
            {
                tcs.TrySetResult(true);
                watcher.Created -= createdHandler;
                watcher.Dispose();
            }
        };
    
        renamedHandler = (s, e) =>
        {
            if (e.Name == Path.GetFileName(path))
            {
                tcs.TrySetResult(true);
                watcher.Renamed -= renamedHandler;
                watcher.Dispose();
            }
        };
    
        watcher.Created += createdHandler;
        watcher.Renamed += renamedHandler;
    
        watcher.EnableRaisingEvents = true;
    
        return tcs.Task;}
      
    	
    So the first key point is that you can use a FileSystemWatcher to be notified when a file system event changes at a particular path. If you, for example, want to be notified when a file is created at a particular location you can find out.
    
    Next, we can create a method that uses a TaskCompletionSource to trigger the completion of a task when the file system watcher triggers the relevant event.
    
        public static Task WhenFileCreated(string path)
        {
            if (File.Exists(path))
                return Task.FromResult(true);
        
            var tcs = new TaskCompletionSource<bool>();
            FileSystemWatcher watcher = new FileSystemWatcher(Path.GetDirectoryName(path));
        
            FileSystemEventHandler createdHandler = null;
            RenamedEventHandler renamedHandler = null;
            createdHandler = (s, e) =>
            {
                if (e.Name == Path.GetFileName(path))
                {
                    tcs.TrySetResult(true);
                    watcher.Created -= createdHandler;
                    watcher.Dispose();
                }
            };
        
            renamedHandler = (s, e) =>
            {
                if (e.Name == Path.GetFileName(path))
                {
                    tcs.TrySetResult(true);
                    watcher.Renamed -= renamedHandler;
                    watcher.Dispose();
                }
            };
        
            watcher.Created += createdHandler;
            watcher.Renamed += renamedHandler;
        
            watcher.EnableRaisingEvents = true;
        
            return tcs.Task;
        }
