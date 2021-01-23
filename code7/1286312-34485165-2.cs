        public void StartWatchers()
        {
            string[] ArrayPaths = new string[2];
            List<FileSystemWatcher> watchers = new List<FileSystemWatcher>();
            ArrayPaths[0] = @"K:\Daily Record Checker\Test\Test1";
            ArrayPaths[1] = @"K:\Daily Record Checker\Test\Test2";
            int i = 0;
            foreach (String String in ArrayPaths)
            {
                watcher.add(MyWatcherFatory(ArrayPaths[i]));
                i++;
            }
            //Do other stuff....
            //....
            //Start my watchers...
            foreach (FileSystemWatcher watcherin watchers )
            {
                watcher.EnableRaisingEvents = true;;
                i++;
            }
        }
        FileSystemWatcher MyWatcherFatory(string path)
        {
            FileSystemWatcher watcher = new FileSystemWatcher(path);
            watcher.Changed += Watcher_Created;
            watcher.Path = path;
            watcher.Filter = "*.csv";
            return watcher;
        }
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            FileInfo fileInfo = new FileInfo(e.FullPath);
            if (!IsFileLocked(fileInfo))
            {
                CheckNumberOfRecordsInFile(e.FullPath);
            }          
        }
