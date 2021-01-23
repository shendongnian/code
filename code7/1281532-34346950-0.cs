    FileSystemWatcher objWatcher = new FileSystemWatcher(); 
    objWatcher.Changed += new FileSystemEventHandler(OnChanged); 
    
    string[] filters = new string[] { "test", "blah", ".exe"}; //this needs to be a member of the class so it can be accessed from the Changed event
    
    private static void OnChanged(object source, FileSystemEventArgs e) 
    { 
        if (filters.Any(e.FullPath).Contains))
        {     
            string strFileExt = getFileExt(e.FullPath); 
        }
    }
