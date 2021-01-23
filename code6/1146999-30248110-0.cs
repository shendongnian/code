    public class Item
    {
        [XmlElement("title")]
        public Title Title { get; set; }
    
        [XmlElement("link")]
        public string Link { get; set; }
    }
    
    public class Title
    {
        [XmlAttribute("short")]
        public string Short { get; set; }
    
        [XmlText]
        public string Value { get; set; }
    }
