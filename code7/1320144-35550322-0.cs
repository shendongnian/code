    class Program
    {
        static void Main(string[] args)
        {
            var watcher = new System.IO.FileSystemWatcher()
            {
                Path =  @"G:\cc\",
            };
            watcher.Created += Watcher_Created;
            watcher.EnableRaisingEvents = true;
            Console.ReadKey();
        }
        private static void Watcher_Created(
            object sender, 
            FileSystemEventArgs e
            )
        {
            var folder = new DirectoryInfo(e.FullPath)
                .Parent;
            Console.WriteLine(
                folder?
                    .GetFiles()
                    .Length
                );
        }
    }
