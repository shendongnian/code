    [XmlRoot]
    public class Reader
    {
        [XmlElement]
        public NewRecord NewRecord;
        [XmlElement]
        public FileTerminator FileTerminator;
        [XmlElement]
        public OutputFont OutputFont;
    }
    public class NewRecord
    {
        [XmlAttribute]
        public string value;
    }
    public class FileTerminator
    {
        [XmlAttribute]
        public string value;
    }
    public class OutputFont
    {
        [XmlAttribute]
        public string value;
    }
    var t = o.Deserialize("xml"); // works
