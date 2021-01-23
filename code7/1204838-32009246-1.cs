    public class PO
    {
        public string PONUM { get; set; }
        [XmlElement("DESCRIPTION")]
        public string PODESCRIPTION { get; set; }
        [XmlElement("POLINE")]
        public List<POLINES> POLines { get; set; }
    }
    public class POLINES
    {
        public string POLINENUM { get; set; }
        [XmlElement("NAME")]
        public string LINEDESCRIPTION { get; set; }
    }
