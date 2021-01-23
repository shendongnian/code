    public class FileSystemProvider : IFileSystemProvider
    {
        private readonly IFilesLibraryConfiguration configuration;
    
        public FileSystemProvider(IFilesLibraryConfiguration configuration)
        {
            this.configuration = configuration;
        }
    
        public string ReadAllText(string virtualPath)
        {
            var fullPath = VirtualPathToFullPath(virtualPath);
    
            var allText = File.ReadAllText(fullPath);
            return allText;
        }
    
        public bool FileExists(string virtualPath)
        {
            var fullPath = VirtualPathToFullPath(virtualPath);
    
            return File.Exists(fullPath);
        }
    
        private string VirtualPathToFullPath(string virtualPath)
        {
            return HostingEnvironment.MapPath(virtualPath);
        }
    }
