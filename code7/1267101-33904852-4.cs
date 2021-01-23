    public class FileHeaderList2 : FileHeaderBase
    {
        private IList<string> _fileHeaders;
        protected override IList<string> FileHeaders
        {
            get
            {
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
