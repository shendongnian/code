    public class sst
    {
        [XmlAttribute]
        public string uniqueCount;
        [XmlAttribute]
        public string count;
        [XmlElement("si")]
        public SharedString[] si;
        
        public sst() { }
    }
    public class SharedString
    {
        public string t;
        [XmlElement("r")]
        public NestedString[] ns;
        public SharedString() { }
    }
    
    public class NestedString
    {
        public string t;
    }
