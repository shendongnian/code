    private static void Main(string[] args)
    {
        while (true)
        {
            CallWatcher();
        }
    }
    private static void CallWatcher() 
    {
        var watcher = new FileSystemWatcher();
        try
        {
            // do watcher stuff here
        }
        finally 
        {
            watcher.Dispose();
        }
    }
