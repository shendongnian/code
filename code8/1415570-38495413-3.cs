    private void button1_Click(object sender, EventArgs e)
            {
                var watcher = new FileSystemWatcher();
                watcher.Created += new FileSystemEventHandler(fileSystemWatcher1_Changed);
                watcher.Path = @"c:\temp";
                watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size;
                watcher.EnableRaisingEvents = true;
            }
    
            private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
            {
                Thread.Sleep(100); // <- give the Creator some time. Increase value for greate pause
                if (IsImage(e.FullPath))
                {
                    Console.WriteLine("success----------->" + e.FullPath);
                }
            }
