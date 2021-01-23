    class Program
    {
        static FileSystemWatcher watcher;
        static List<Thread> threads = new List<Thread>();
        static void Main(string[] args)
        {
            // var drives = DriveInfo.GetDrives();
            DriveInfo[] drives = DriveInfo.GetDrives();
            for (int i = 0; i < drives.Length; i++)
            {
                var drive = drives[i];
                if (drive.DriveType == DriveType.Removable)
                {
                    Console.WriteLine("Watching drive " + drive.Name);
    
                    Thread t = new Thread(new ParameterizedThreadStart(watch));
                    t.Start(drive.Name);
    
                    threads.Add(t);
                }
    
            }
            while(Console.ReadKey().Key != ConsoleKey.Q )
                    { Thread.SpinWait(10); }
            Console.Write("done");
            Console.ReadLine();
    
        }
    
        static void watch(object pth)
        {
            string path = (string)pth;
    
            watcher = new FileSystemWatcher();
            watcher.Created += watcher_Created;//register event to be called when a file is created in specified path
            watcher.Changed += watcher_Changed;//register event to be called when a file is updated in specified path
            watcher.Deleted += watcher_Deleted;//register event to be called when a file is deleted in specified path
    
            watcher.Path = path;//assigning path to be watched
            watcher.IncludeSubdirectories = true;//make sure watcher will look into subfolders as well.
            watcher.Filter = "*.*"; //watcher should monitor all types of file.
            watcher.EnableRaisingEvents = true;//make sure watcher will raise event in case of change in folder.
    
        }
    
        static void watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File : " + e.FullPath + " is deleted.");
        }
    
        static void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File : " + e.FullPath + " is updated.");
        }
    
        static void watcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File : " + e.FullPath + " is created.");
        }
    }
