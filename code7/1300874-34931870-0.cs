    public class Service
    {
        [XmlElement("ServiceDescription")]
        public string ServiceDescription { get; set; }
        [XmlElement("Provider")]
        public string Provider { get; set; }
        [XmlElement("StartDate")]
        public string StartDate { get; set; }
        [XmlElement("EndDate")]
        public string EndDate { get; set; }
        [XmlElement("Type")]
        public string Type { get; set; }
    }
    [XmlType("Warranty")]
    public class Warranty
    {        
        [XmlElement("Service")]
        public Service objWarranty = new Service();
        [XmlAttribute("Services")]
        public string Services {get; set;}
    }
