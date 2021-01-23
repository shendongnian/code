    public class FileMonitor
        {
            public int Counter { get; set; }
            public FileSystemWatcher Watcher { get; set; }
            public FileMonitor(string path)
            {
                Counter = 0;
                Watcher = new FileSystemWatcher();
                Watcher.Path = path;
                Watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                Watcher.Filter = "*.csv";
                Watcher.Changed += (s, e) => OnChanged();
    
                Watcher.EnableRaisingEvents = true;
            }
    
            private void OnChanged()
            {
                try
                {
                    Watcher.EnableRaisingEvents = false;
                    MessageBox.Show(Counter.ToString());
                    Counter = Counter + 1;
                }
                finally
                {
                    Watcher.EnableRaisingEvents = true;
                }
            }
        } 
