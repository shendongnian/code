        public FileWatcher()
        {
            fsw = new FileSystemWatcher();
            random = new Random();
            fsw.Path = @"C:\FileMover\A";
            fsw.Created += fsw_Created;
            fsw.Changed += fsw_Created;
            fsw.EnableRaisingEvents = true;
        }
