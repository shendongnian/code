    [XmlRoot("members")]
    public class DocFile
    {
        [XmlElement("member")]
        public List<DocItem> Items = new List<DocItem>();
    }
