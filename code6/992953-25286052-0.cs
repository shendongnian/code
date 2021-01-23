    public static void Lock(string path, Action<FileStream> action) {
        var autoResetEvent = new AutoResetEvent(false);
     
        while(true)
        {
            try
            {
                using (var file = File.Open(path,
                                            FileMode.OpenOrCreate,
                                            FileAccess.ReadWrite,
                                            FileShare.Write))
                {
                    action(file);
                    break;
                }
            }
            catch (IOException)
            {
                var fileSystemWatcher =
                    new FileSystemWatcher(Path.GetDirectoryName(path))
                            {
                                EnableRaisingEvents = true
                            };
     
                fileSystemWatcher.Changed +=
                    (o, e) =>
                        {
                            if(Path.GetFullPath(e.FullPath) == Path.GetFullPath(path))
                            {
                                autoResetEvent.Set();
                            }
                        };
     
                autoResetEvent.WaitOne();
            }
        } 
    }
