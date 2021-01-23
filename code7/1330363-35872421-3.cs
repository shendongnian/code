        static void Main(string[] args)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = @"Path here";
            watcher.NotifyFilter = NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Filter = "*.txt";
            watcher.Created += new FileSystemEventHandler(OnCreated);
            watcher.EnableRaisingEvents = true;
            Console.Read();
        }
        static void OnCreated(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("Created file: " + e.FullPath);
            System.Diagnostics.Process.Start(e.FullPath);
        }
