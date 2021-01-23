    public class FileHeaderList1 : FileHeaderBase
    {
        private readonly IList<string> _fileHeaders = new List<string>
        {
            "Last Name" ,
            "First Name" ,
            "Middle Name" ,
            "Suffix" ,
            "Degree" ,
        };
        protected override IList<string> FileHeaders => _fileHeaders;        
    }
