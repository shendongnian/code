    public interface IFileHeaders
    {
        IList<string> GetFileHeaders();
    }
    public abstract class FileHeaderBase : IFileHeaders
    {
        protected abstract IList<string> FileHeaders { get; }
        public IList<string> GetFileHeaders() => FileHeaders;
    }
    public class FileHeaderList1 : FileHeaderBase
    {
        private readonly List<string> _fileHeaders = new List<string>
        {
            "Last Name" ,
            "First Name" ,
            "Middle Name" ,
            "Suffix" ,
            "Degree" ,
        };
        protected override IList<string> FileHeaders => _fileHeaders;        
    }
    public class FileHeaderList2 : FileHeaderBase
    {
        private List<string> _fileHeaders;
        protected override IList<string> FileHeaders
        {
            get
            {
                // Lazy loading
                if ( _fileHeaders == null )
                {
                    _fileHeaders = new List<string>
                    {
                        "Address" ,
                    };
                }
                return _fileHeaders;
            }
        }
    }
