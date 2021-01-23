    public class Gps
    {
        [XmlElement("head")]
        public HeadData Head { get; set; }
        [XmlArray("events")]
        [XmlArrayItem("event")]
        public List<EventData> Events { get; set; }
        public class HeadData
        {
            [XmlAttribute("nemo")]
            public string Nemo { get; set; }
            [XmlAttribute("dte")]
            public DateTime Dte { get; set; }
        }
        
        public class EventData
        {
            [XmlAttribute("type")]
            public string Type { get; set; }
            [XmlAttribute("desc")]
            public string Desc { get; set; }
            [XmlElement("gps")]
            public GpsData Gps { get; set; }
        }
        public class GpsData
        {
            [XmlAttribute("id")]
            public string Id { get; set; }
            [XmlAttribute("dte")]
            public DateTime Dte { get; set; }
        }
    }
