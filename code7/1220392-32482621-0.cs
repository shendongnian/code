        static void Main(string[] args)
        {
            FileSystemWatcher();
        }
        public static void FileSystemWatcher()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = @"D:\temp";
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Filter = "*.*";
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += Watcher_Created;
            watcher.EnableRaisingEvents = true;
            Console.Read();
        }
        private static void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine(e.Name + " has been added");
        }
        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine(e.Name + " has changed");
        }
