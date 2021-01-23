    [XmlRoot("Data")]
    public class Overflow
    {
        [XmlElement]
        public string Name { get; set; }
    
        [XmlElement]
        public decimal MoneySpent { get; set; }
    
        [XmlElement]
        public string Code { get; set; }
    }
