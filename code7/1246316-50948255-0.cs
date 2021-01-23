    public class FileSystemWatcherWrapper : FileSystemWatcher, IFileSystemWatcherWrapper
        {
          //empty on purpose, doesnt need any code
        }
     public interface IFileSystemWatcherWrapper
        {
            event FileSystemEventHandler Created;
            event FileSystemEventHandler Deleted;
            bool EnableRaisingEvents { get; set; }
    
            bool IncludeSubdirectories { get; set; }
    
            string Path { get; set; }
            string Filter { get; set; }
    
            void Dispose();
        }
    }
