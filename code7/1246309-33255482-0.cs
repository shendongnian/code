    public class FileSystemWatcherWrapper
    {
        private readonly FileSystemWatcher watcher;
        public event FileSystemEventHandler Changed;
        public FileSystemWatcherWrapper(FileSystemWatcher watcher)
        {
            watcher.Changed += this.Changed;
        }
        public bool EnableRaisingEvents
        {
            get { return watcher.EnableRaisingEvents; }
            set { watcher.EnableRaisingEvents = value; }
        }
    }
