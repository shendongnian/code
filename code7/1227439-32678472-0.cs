    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static HashSet<string> oldDirFiles = new HashSet<string>();
            static HashSet<string> newDirFiles = new HashSet<string>();
    
            static string oldDir = "C:\\New Folder";
            static string newDir = "C:\\New Folder 2";
    
            static System.Threading.ManualResetEvent resetEvent = new System.Threading.ManualResetEvent(false);
    
            static void Main(string[] args)
            {
                System.IO.FileSystemWatcher watcher = new System.IO.FileSystemWatcher();
                watcher.Path = newDir;
                watcher.NotifyFilter = NotifyFilters.DirectoryName | NotifyFilters.FileName;
                watcher.IncludeSubdirectories = true;
                watcher.Filter = "*.*";
                watcher.Created += watcher_Created;
                watcher.Changed += watcher_Changed;
                watcher.Renamed += watcher_Renamed;
                watcher.EnableRaisingEvents = true;
    
                //get all files in old directory
                var oldFiles = Directory.GetFiles(oldDir, "*.*", SearchOption.AllDirectories);
                foreach (var file in oldFiles)
                    oldDirFiles.Add(file);
    
                resetEvent.WaitOne();
    
                //now launch the directory copy
    
                //then you have to check if in the meaning time, new files were added or renamed
                //that could be done also with a watcher in the old directory
            }
    
            static void watcher_Renamed(object sender, RenamedEventArgs e)
            {
                throw new NotImplementedException();
            }
    
            static void watcher_Changed(object sender, FileSystemEventArgs e)
            {
                throw new NotImplementedException();
            }
    
            static void watcher_Created(object sender, FileSystemEventArgs e)
            {
                //check if the copied file was in the old directory before starting
                if (oldDirFiles.Contains(e.FullPath.Replace(newDir, oldDir)))
                {
                    newDirFiles.Add(e.FullPath);
                    //if all the files have been copied, the file count will be the same in the two hashsets
                    //the resetevent.Set() signal the waiting thread and the program can proceed
                    if (newDirFiles.Count == oldDirFiles.Count)
                        resetEvent.Set();
                }
            }
        }
    }
