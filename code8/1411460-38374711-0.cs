    [XmlRoot(Namespace = "StaffinfOrderNamespace")]
    public class StaffingOrder
    {    
        public OrderId OrderId { get; set; }    
    }
    
    public class OrderId
    {
        [XmlAttribute("idOwner")]
        public string IdOwner { get; set; }
           
        [XmlElement("IdValue")]
        public List<IdValue> IdValues { get; set; }
    }
    
    public class IdValue
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    
        [XmlText]
        public int Value { get; set; }
    }
