    using System.Threading.Tasks;
    namespace ConsoleApplication4
    {
        class Program
        {
            static string importerProcessName = "import.exe";
            static string RootFolder = @"E:\temp\A\";
            static string queuePath = System.IO.Path.Combine(RootFolder, "Queue" );
            static string processingPath = System.IO.Path.Combine(RootFolder, "Processing");
            static string donePath = System.IO.Path.Combine(RootFolder, "Done");
            static void Main(string[] args)
            {
                GrantFolders(); // Make sure we have all our folders ready for action...
                var watcher = new System.IO.FileSystemWatcher(queuePath, "*.txt");
                watcher.Created += watcher_Created;
                watcher.EnableRaisingEvents = true;
                System.Console.ReadLine();
            }
            static Task ProcessFile( string fileName )
            {
                Task task = new Task(() =>
                {
                    System.Console.WriteLine("Processing: " + fileName);
                    System.IO.File.Move(System.IO.Path.Combine(queuePath, fileName), System.IO.Path.Combine(processingPath, fileName));
                    string commandLine = "-import " + System.IO.Path.Combine(processingPath, fileName);
                    using (var importer = new System.Diagnostics.Process())
                    {
                        importer.StartInfo = new System.Diagnostics.ProcessStartInfo(importerProcessName, commandLine);
                        importer.Start();
                        importer.WaitForExit(20000);
                        System.IO.File.Move(System.IO.Path.Combine(processingPath, fileName), System.IO.Path.Combine(donePath, fileName));
                        System.Console.WriteLine("Done with: " + fileName);
                    }
                });
                return task;
            }
            static void watcher_Created(object sender, System.IO.FileSystemEventArgs e)
            {
                System.Console.WriteLine("Found in queue: " + e.Name);
                var task = ProcessFile(e.Name);
                task.Start();
            }
            private static void GrantFolders()
            {
                string[] paths = new string[] { queuePath, processingPath, donePath };
                foreach( var path in paths)
                {
                    if(!System.IO.Directory.Exists(path))
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }
                }
            }
        }
    }
