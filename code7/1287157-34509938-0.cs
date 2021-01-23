    namespace DocumentXml
    {
        [XmlRoot("Document")]
        public class Document
        {
            [XmlArray("Sectors")]
            [XmlArrayItem("Sector")]
            public Sector[] Sectors { get; set; }
        }
        [XmlRoot("Sector")]
        public class Sector
        {
            [XmlAttribute("SectorName")]
            public string SectorName { get; set; }
            [XmlArray("Subsectors")]
            [XmlArrayItem("Subsector")]
            public string[] Subsectors { get; set; }
        }
    }
