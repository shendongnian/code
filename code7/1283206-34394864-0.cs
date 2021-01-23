    public static class FileSystem
    {
        static Lazy<IFileSystem> _fileSystem = new Lazy<IFileSystem>(() => CreateFileSystem(), System.Threading.LazyThreadSafetyMode.PublicationOnly);
        public static IFileSystem Current
        {
            get
            {
                IFileSystem ret = _fileSystem.Value;
                if (ret == null)
                {
                    throw new NotImplementedException();
                }
                return ret;
            }
        }
        static IFileSystem CreateFileSystem()
        {
            return null;
        }
    }
