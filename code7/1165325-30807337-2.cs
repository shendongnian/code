    public void AddWatcher(String wPath) {
        FileSystemWatcher fsw = new FileSystemWatcher();
        fsw.Path = wPath;
        fsw.Created += file_OnCreated;
        fsw.Changed += file_OnChanged;
        fsw.Deleted += file_OnDeleted;
        fsWatchers.Add(fsw);
    }
    private void file_OnDeleted(object sender, FileSystemEventArgs e) {
          
    }
    private void file_OnChanged(object sender, FileSystemEventArgs e) {
           
    }
    private void file_OnCreated(object sender, FileSystemEventArgs e) {
         
    }
