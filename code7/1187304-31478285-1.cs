    public static class FileWatcherMap
    {
        private static Dictionary<string, FileSystemWatcher> _fileSystemWatcherMap = new Dictionary<string,FileSystemWatcher>();
        public static void AddWatcher(string path, FileSystemWatcher fsw)
        {
            _fileSystemWatcherMap.Add(path, fsw);
        }
        public static void RemoveWatcher(string path)
        {
            _fileSystemWatcherMap.Remove(path);
        }
    }
