    [XmlType("detail")]
    public class Detail
    {
        [XmlElement("reference")]
        public string Reference { get; set; }
    }
    
    [XmlRoot("rootNode")]
    public class Root
    {
        [XmlAttribute("date")]
        public string Date { get; set; }
    
        [XmlAttribute("time")]
        public string Time { get; set; }
    
        [XmlAttribute("Details")]
        List<Detail> Details  { get; set; }
    
    }
