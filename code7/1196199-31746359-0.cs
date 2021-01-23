    [XmlRoot(ElementName = "FooBars", Namespace = "http://foos")]
    public class FooBars
    {
        [XmlElement(ElementName = "Id1", Namespace = "http://bars")]
        public string Id1 { get; set; }
    
        [XmlElement(ElementName = "Id2", Namespace = "http://bars")]
        public string Id2 { get; set; }  
    
        [XmlElement(ElementName = "Info", Namespace = "http://bars")]
        public Info Information { get;set; }
    
    }
    
    public class Info {
        [XmlElement(ElementName = "Data", Namespace = "")]
        public Info[] Info { get; set; }
    }
    public class Data
    {
        [XmlElement(ElementName = "Field1")]
        public string Field1 { get; set; }
    
        [XmlElement(ElementName = "Field2")]
        public string Field2 { get; set; }
    }
