    public class Employee
    {
        [XmlAttribute]
        public string Id {get;set;}
        public List<Property> Properties {get;set;}
    }
    public class Manager
    {
        [XmlAttribute]
        public string Id {get;set;}
        public List<Property> Properties {get;set;}
    }
