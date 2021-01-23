    using System;
    using System.IO;
    using System.Security.Permissions;
    public class Watcher
    {
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static void Run()
        {
            string[] args = System.Environment.GetCommandLineArgs();
            // if the directory is not specified, exit the program
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: Watcher.exe (directory)");
                return;
            }
            // Create the file watcher and set its properties
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = args[1];
            // Watch for changes
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.LastAccess | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // only watch text files for now.
            watcher.Filter = ".txt";
            // Event handlers
            watcher.Changed += Watcher_Changed;
            watcher.Created += Watcher_Changed;
            watcher.Deleted += Watcher_Changed;
            watcher.Renamed += Watcher_Renamed;
            // Begin watching
            watcher.EnableRaisingEvents = true;
            // Wait for users to quit the program
            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;
        }
        private static void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
        }
        private static void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
        }
    }
