    [Serializable]
    public class MyDocument
    {
        [XmlElement(IsNullable = False)]
        public int Property1 { get; set }
        
        [XmlArray(IsNullable= False)]
        public List<string> Property2 { get; set; }
    }
