    System.IO.FileSystemWatcher m_Watcher = new System.IO.FileSystemWatcher(); 
    m_Watcher.Path = folderPath; 
    m_Watcher.Filter = strFilter; 
    m_Watcher.NotifyFilter = NotifyFilters.LastAccess | 
                         NotifyFilters.LastWrite | 
                         NotifyFilters.FileName | 
                         NotifyFilters.DirectoryName;
    m_Watcher.Changed += new FileSystemEventHandler(OnChanged);
    m_Watcher.Created += new FileSystemEventHandler(OnChanged);
