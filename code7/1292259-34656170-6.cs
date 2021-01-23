    public class Document
    {
        public List<string> fullFilePath;
        public bool isPatch;
        public string destPath;
    
    
        public Document() 
        {
             fullFilePath = new List<string>(); 
        }
    
        public Document(string aFile, bool isPatch, string destPath)
        {
            this.fullFilePath.Add(aFile);
            this.isPatch = isPatch;
            this.destPath = destPath;
        }
        public void AddFile(string aFile)
        {
            this.fullFilePath.Add(aFile);
        }
    }
