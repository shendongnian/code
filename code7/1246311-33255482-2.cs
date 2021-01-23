    public class TheClassThatActsOnFilesystemChanges
    {
        private readonly IFileSystemWatcherWrapper fileSystemWatcher;
        public TheClassThatActsOnFilesystemChanges(IFileSystemWatcherWrapper fileSystemWatcher)
        {
            this.fileSystemWatcher = fileSystemWatcher;
            fileSystemWatcher.Changed += (sender, args) =>
            {
                //Do something...
            };
        }
    }
