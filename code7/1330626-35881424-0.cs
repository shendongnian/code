    public class DirectoryRefresher : IDisposable
    {
        private FileSystemWatcher FileWatcher { get; set; }
        
        public DirectoryRefresher(string directorypath)
        {
            FileWatcher = SetupFileWatcher(directoryPath);
        }
        protected FileSystemWatcher SetupFileWatcher(string path)
        {
            var watcher = new FileSystemWatcher(path);
            watcher.Changed += (sender, e) => { DoYourProcessing(e.FullPath); };
            watcher.Created += (sender, e) => { DoYourProcessing(e.FullPath); };
            watcher.Deleted += (sender, e) => { DoYourProcessing(e.FullPath); };
            watcher.EnableRaisingEvents = true;
            return watcher;
        }
        public void DoYourProcessing(string filePath)
        {
            ...
        }
        public void Dispose()
        {
            try
            {
                if (FileWatcher != null)
                {
                    FileWatcher.Dispose();
                    FileWatcher = null;
                }
            }
            catch
            {
                // ignored
            }
        }
    }
