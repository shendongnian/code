    public class FileContainerFactory : IFileContainerFactory 
    {
        private readonly IServiceProvider provider;
        public class FileContainerFactory(IServiceProvider provider)
        {
            this.provider = provider;
        }
        public IFileContainer CreateFileSystemContainer() 
        {
            // resolve it via built in IoC
            return provider.GetService<FsFileContainer>();
        }
        public IFileContainer CreateFtpContainer() 
        {
            // resolve it via built in IoC
            return provider.GetService<FtpFileContainer>();
        }
    }
