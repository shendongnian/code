    public interface IFileSystemWatcherWrapper
    {
        event FileSystemEventHandler Changed;
        bool EnableRaisingEvents { get; set; }
    }
    //and therefore...
    public class FileSystemWatcherWrapper : IFileSystemWatcherWrapper
