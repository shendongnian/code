    public interface IFileHeaders
    {
        IList<string> GetFileHeaders();
    }
    public abstract class FileHeaderBase : IFileHeaders
    {
        protected abstract IList<string> FileHeaders { get; }
        public IList<string> GetFileHeaders() => FileHeaders;
    }
