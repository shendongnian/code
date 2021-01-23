    public class Record
    {
        [System.Xml.Serialization.XmlAttribute("PLU")]
        public int PLU { get; set; }
        [System.Xml.Serialization.XmlAttribute("NAZWA01")]
        public string Nazwa01 { get; set; }
        [System.Xml.Serialization.XmlAttribute("UNITPRICE")]
        public int UnitPrice { get; set; }
        [System.Xml.Serialization.XmlAttribute("ITEMCODE")]
        public string ItemCode { get; set; }
        [System.Xml.Serialization.XmlAttribute("GROUP")]
        public string Group { get; set; }
    }
