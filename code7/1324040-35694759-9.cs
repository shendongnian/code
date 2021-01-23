    public interface IFileProcessorFactory
    {
        FileProcessor Create(FileCode fileCode);
    }
    internal class FileProcessorFactory : IFileProcessorFactory
    {
        private readonly IResolutionRoot resolutionRoot;
        public FileProcessorFactory(IResolutionRoot resolutionRoot)
        {
            this.resolutionRoot = resolutionRoot;
        }
        public FileProcessor Create(FileCode fileCode)
        {
            return this.resolutionRoot.Get<FileProcessor>(new FileCodeParameter(fileCode));
        }
    }
