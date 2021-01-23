    public class DocumentProperties
    {
        public DocumentProperties()
        {
            Document = new List<Document>();
        }
        [XmlElement("Document")]
        public List<Document> Document { get; set; }
    }
    public class Document
    {
        public Document()
        {
            Properties = new List<Properties>();
        }
        [XmlElement("Properties")]
        public List<Properties> Properties { get; set; }
        public string targetFolder { get; set; }
    }
