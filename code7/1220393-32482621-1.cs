        static void Main(string[] args)
        {
            FileSystemWatcher();
        }
        public static void FileSystemWatcher()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = @"D:\temp";
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
       | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Filter = "*.*";
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += Watcher_Created;
            watcher.Renamed += Watcher_Renamed;
            watcher.EnableRaisingEvents = true;
            Console.Read();
        }
        private static void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine(e.Name + " has been renamed");
        }
        private static void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine(e.Name + " has been added");
        }
        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine(e.Name + " has changed");
        }
