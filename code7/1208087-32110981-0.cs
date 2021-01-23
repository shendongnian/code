    public class Document2
    {
        public string propertyname { get; set; }
        public string propertyvalue { get; set; }
    }
    public class Document
    {
        public List<Document2> document { get; set; }
    }
    public class RootObject
    {
        public List<Document> documents { get; set; }
    }
