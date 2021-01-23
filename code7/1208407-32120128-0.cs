    using System.Collections.Generic;
    using System.Xml.Serialization;
    
    public class sizes
    {
        [XmlAttribute("type")]
        public string type { get; set; }
    
        [XmlElement("size")]
        public List<size> sizeList { get; set; }
    }
    
    public class size
    {
        [XmlAttribute("status")]
        public string status { get; set; }
    }
