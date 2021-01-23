    class Cleaner : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private List<KeyValuePair<string, ulong>> _memoryPool = new List<KeyValuePair<string, ulong>>();
        public List<KeyValuePair<string, ulong>> MemoryPool
        {
            get { return _memoryPool; }
            set
            {
                _memoryPool = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("MemoryPool"));
            }
        }
        private void watch()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Filter = "*.*";
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
        }
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            UpdateCollection();
        }
        private void UpdateCollection()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);;
            System.IO.DirectoryInfo di = new DirectoryInfo(path);
            CacheFiles = di.GetFiles().ToList();
        }
        public Cleaner()
        {
            UpdateCollection();
            watch();
        }
    }
