    [XmlRoot("category")]
    public class Category
    {
        public Category() { }
    
        [XmlElement("parent-id")]
        public int ParentId {get;set}
    
        [XmlElement("name")]
        public string Name {get;set}
    
        [XmlElement("count")]
        public int Count {get;set}
    
        [XmlElement("id")]
        public string Id {get;set}
    
        [XmlElement("elements_count")]
        public int ElementsCount {get;set}
    
        [XmlElement("type")]
        public string Type {get;set}
    }
