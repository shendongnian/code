    [XmlRoot("result")]
    public class Result
    {
        [XmlElement("rowset")]
        public DivisionSet[] DivisionSets { get; set; }
    }
    
    public class DivisionSet
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    
        [XmlElement("row")]
        public Division[] Divisions { get; set; }
    }
    
    public class Division
    {
        [XmlAttribute("accountKey")]
        public int AccountKey { get; set; }
    
        [XmlAttribute("description")]
        public string Description { get; set; }
    }
