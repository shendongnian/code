    void Main()
    {
    	FileSystemWatcher fsw = new FileSystemWatcher(@"c:\Temp\");
    	fsw.IncludeSubdirectories = true;
    	fsw.Changed += new FileSystemEventHandler(OnChanged);
    	fsw.EnableRaisingEvents = true;
    	while (true) { }
    }
    
    void OnChanged(object source, FileSystemEventArgs e)
    {
    	// Specify what is done when a file is changed, created, or deleted.
    	Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
    }
