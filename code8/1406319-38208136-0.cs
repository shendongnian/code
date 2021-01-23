    static FileSystemWatcher watcher;
    
    private static void Run()
    {
        // Create a new FileSystemWatcher and set its properties.
        // if you're watching a network share, don't expect huge performance
        // as the network is involved
        watcher = new FileSystemWatcher
        {
            Path = $@"\\file\home$\{UserName}\Application Data",
            NotifyFilter =  
                NotifyFilters.LastWrite,
            Filter = "filetowatch.txt"
        };
    
        // Activate
        watcher.Changed += OnChanged;
        watcher.EnableRaisingEvents = true;
    
        AppDomain.CurrentDomain.DomainUnload += (s,e) => { 
          var w = watcher as IDisposable;
          if (w != null) w.Dispose(); 
        };
    }
