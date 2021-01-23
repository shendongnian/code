    public class Document
    {
        public List<string> fullFilePath;
        public bool isPatch;
        public string destPath;
    
    
        public Document() { }
    
        public Document(List<string> fullFilePath, bool isPatch, string destPath)
        {
            this.fullFilePath = fullFilePath;
            this.isPatch = isPatch;
            this.destPath = destPath;
        }
    }
