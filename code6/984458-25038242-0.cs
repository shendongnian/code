    [DataContract]
    public class FruitCrate
    {
      [XmlAttribute]
      public int NumberOfFruits;
    
      [DataMember(Name = "Cats")]
      public CatContainer CatContainer;
    }
    
    [DataContract]
    public class Cats2009
    {
        [DataMember]
        public string Name;
    }
    [DataContract]
    public class CatContainer
    {
        [XmlAttribute]
        public string MomName;
    
        [DataMember]
        public List<Cats2009> Cats;
    }
