    public class FileHeaderList3 : FileHeaderBase
    {
        private readonly IList<string> _fileHeaders;
        public FileHeaderList3( IList<string> fileHeaders )
        {
            _fileHeaders = fileHeaders;
        }
        protected override IList<string> FileHeaders => _fileHeaders;
    }
