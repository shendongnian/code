    public class Item
    {
        [XmlElement("id")]
        public int Id { get; set; }
    
        [XmlElement("name")]
        public string Name { get; set; }
    
        [XmlElement("resistance")]
        public Resistance Resistance { get; set; }
    }
    
    public class Resistance
    {
        [XmlArray("physical")]
        [XmlArrayItem("phy")]
        public float[] Phyres { get; set; }
    
        [XmlArray("air")]
        [XmlArrayItem("air")]
        public float[] Air { get; set; }
    }
