    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class FruitCrate
    {
        [XmlAttribute]
        public int id;
        [DataMember]
        public List<Setting> Settings;
    }
    
    [DataContract(Name = "Settings")]
    public class Setting
    {
        [XmlAttribute]
        public int id;
        [XmlElement]
        public List<Fruit> Fruits;
    }
