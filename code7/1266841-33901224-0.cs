        [XmlElement("BUZEI")]
        public string Buzei { get; set; }
        [XmlElement("BUKRS")]
        public string Bukrs { get; set; }
    }
    public class Header
    {
        [XmlElement("MANDT")]
        public string Mandt { get; set; }
        [XmlElement("BELNR")]
        public string Belnr { get; set; } 
    }
    public class ControlFields
    {
        [XmlElement("STRUCTURID")]
        public string StructuredId { get; set; }
        [XmlElement("OPERA")]
        public string Opera { get; set; }
        [XmlElement("WIID")]
        public string Wild { get; set; } 
    }
    public class InvoiceChangeRequest
    {
         [XmlElement("CONTROL_FIELDS")]
        public ControlFields ControlFields { get; set; }
         [XmlElement("HEADER_IN")]
        public Header Header { get; set; }
        [XmlArray("ITEMS")]
        [XmlArrayItem("ITEM_FIELDS_IN")]
        public List<Item> Items { get; set; }
    }
