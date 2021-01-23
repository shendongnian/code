    [XmlRoot("root")]
    class Person
    {
        [XmlElement("general")]
        public General General {get; set;}
    }
    class General
    {
        [XmlAttribute("name")] 
        public strig Name {get;set;}
    }
