    [XmlRoot("Array")]
    public class Data
    {
        public string Name { get; set; }
        public string DimSize { get; set; }
    
        [XmlElement("Cluster")]
        public List<Cluster> Cluster { get; set; }
    }
        
    public class Cluster
    {
        public string Name { get; set; }
        public int NumElts { get; set; }
        
        [XmlElement("U16")]
        public List<U16> U16 { get; set; }
    }
    
    public class U16
    {
        public string Name { get; set; }
        public string Val { get; set; }
    }
