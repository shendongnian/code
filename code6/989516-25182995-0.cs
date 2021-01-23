    [XmlType("trans")]
    public class Trans
    {
        [XmlElement("orderNo")]
        public string OrderNo { get; set; }
    
        [XmlElement("orderDate")]
        public string OrderDate { get; set; }
    
        [XmlArray("orders")]
        public HashSet<Item> Orders { get; set; }
    }
    
    [XmlType("item")]
    public class Item
    {
        [XmlElement("itemName")]
        public string ItemName { get; set; }
    
        [XmlElement("itemAmount")]
        public string ItemAmount { get; set; }
    }
