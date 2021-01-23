    public class Reader
    {
        ...
        [XmlElement("OutputFont")]
        public ReaderItemOutputFont ReaderItem { get; set; }
    }
    
    
    [Serializable()]
    public class ReaderItemOutputFont
    {
        [XmlAttribute("value")]
        public String OutputFont { get; set; }
    }
