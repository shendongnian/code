    public class DocumentType
    {
        public Properties properties { get; set; }
    }
    
    public class RootObject
    {
        public Dictionary<string, DocumentType> mappings { get; set; }
    }
