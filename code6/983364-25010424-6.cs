    public class FileDownloaderRegistry
    {
        private readonly IFileDownload[] _downloaders;
        public FileDownloaderRegistry(IFileDownload[] downloaders)
        {
            _downloaders = downloaders;
        }
    }
