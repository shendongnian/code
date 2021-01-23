    public class FileRetriever
    {
        public IFile CachedFile { get; private set; } 
        
        // Indicate if the CachedFile is the latest version of the file. If not, 
        // then LatestFileTask will complete eventually with the latest revision 
        public bool IsLatestFileVersion { get; private set; } 
        public Task<IFile> LatestFileTask { get; private set; } 
        public FileRetriever(IFile file)
        {
            IsLatestFileVersion = true;
            CachedFile = file;
            LatestFileTask = Task.FromResult(file);
        }
        public FileRetriever(IFile file, Task<IFile> latestFileTask)
        {
            IsLatestFileVersion = false;
            CachedFile = file;
            LatestFileTask = latestFileTask;
        }
    }
