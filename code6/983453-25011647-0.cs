    using System;
    using System.IO;
    
    namespace FileReadTest
    {
        internal class Program
        {
            public static FileSystemWatcher watch()
            {
                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.Path = "d:\\";
                watcher.NotifyFilter = NotifyFilters.LastWrite;
                watcher.Filter = "test.txt";
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.EnableRaisingEvents = true;
                return watcher;
    
            }
            public static void OnChanged(object source, FileSystemEventArgs e)
            {
                string s;
    
                using (StreamReader r = new StreamReader(File.Open("d:\\test.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                {
                    while ((s = r.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
    
            static void Main()
            {
                var watcher = watch();
                Console.ReadKey();
                watcher.Dispose();
            }
        }
    }
