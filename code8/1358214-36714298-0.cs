        [XmlRoot("Person")]
        public class Person
        {
            [XmlElement("Name")]
            public string name {get; set;}
            [XmlElement("Address")]
            public string[] address {get; set;}
        }
