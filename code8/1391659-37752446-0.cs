    [XmlRoot("element")]
    public class Element
    {
        [XmlText]
        public string Text { get; set; }
    
        [XmlElement("subelement")]
        public string Subelement { get; set; }
    }
