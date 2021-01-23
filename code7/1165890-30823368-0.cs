        [XmlRoot("MRData", Namespace = "http://ergast.com/mrd/1.4")]
        public class DriverData
        {
            [XmlAttribute("series")]
            public string series { get; set; }
    
            [XmlAttribute("url")]
            public string url { get; set; }
    
            [XmlAttribute("limit")]
            public int limit { get; set; }
    
            [XmlAttribute("offset")]
            public int offset { get; set; }
    
            [XmlAttribute("total")]
            public int total { get; set; }
    
            [XmlElement("DriverTable")]
            public DriverTable DriverTable { get; set; }
        }
