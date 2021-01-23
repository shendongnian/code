    public class FileData
    {
        public string FilePath { get; set; }
        public ISet<FileInfo> DependentUpon { get; set; }
      
        public IEnumerable<FileInfo> Dependencies {get; set;}
    }
