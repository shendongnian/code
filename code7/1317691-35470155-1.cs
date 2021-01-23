    [Serializable]
    public class OrderMerchant
    {
        [XmlText]
        public string Name { get; set; }
    
        [XmlAttribute("id")]
        public int ID { get; set; }
    }
