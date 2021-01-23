    [Serializable]
    public class OrderXML
    {
        [XmlArray("GROUPLIST")]
        public Group[] GroupList { get; set; }
    }
    
    [Serializable]
    public class Group
    {
        [XmlElement("SELLER", Type = typeof(Seller))]
        public Seller[] Sellers { get; set; }
    }
