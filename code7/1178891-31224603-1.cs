    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace FileWatcher
    {
        class Program
        {
            static int counter = 0;
    
            public static void Main (string[] args)
            {
                var tempDir = Path.GetTempPath ();
                var tempFile = Path.GetTempFileName ();
                var fsw = new FileSystemWatcher (tempDir, Path.GetFileName (tempFile));
                fsw.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size;
                fsw.Changed += WatcherOnChanged;
                fsw.EnableRaisingEvents = true;
                Console.WriteLine ("Created watcher for {0}", tempFile);
                var cts = new CancellationTokenSource ();
                Console.CancelKeyPress += (s, e) => {
                    e.Cancel = true;
                    cts.Cancel ();
                };    
                MainAsync (tempFile, cts.Token).Wait ();
                fsw.Dispose ();
                File.Delete (tempFile);
            }
    
            static async Task MainAsync (string fileName, CancellationToken token)
            {
                while (!token.IsCancellationRequested) {
                    WriteFile (fileName);
                    Thread.Sleep (2000);
                }
            }
    
            private static void WatcherOnChanged (object sender, FileSystemEventArgs eventArgs)
            {
                Console.WriteLine ("Changed: '{0}', type: {1}", eventArgs.FullPath, eventArgs.ChangeType);
                ReadFile (eventArgs.FullPath);
            }
    
            private static void ReadFile (string fileName)
            {
                using (var sr = new StreamReader (File.Open (fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))) {
                    Console.Write (sr.ReadLine ());
                }
            }
    
            private static void WriteFile (string fileName)
            {
                using (var sr = new StreamWriter (fileName, true)) {
                    sr.Write (counter++);
                }
            }
        }
    }
