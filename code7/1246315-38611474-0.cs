    public interface IFileSystemWatcherWrapper : IDisposable
    {        
        bool EnableRaisingEvents { get; set; }
        event FileSystemEventHandler Changed;
        //...
    }
    
    public class FileSystemWatcherWrapper : FileSystemWatcher, IFileSystemWatcherWrapper
    {
        public FileSystemWatcherWrapper(string path, string filter)
            : base(path, filter)
        {
        }
    }
