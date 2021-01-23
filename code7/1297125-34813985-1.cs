    namespace StackOverflow
    {
        public class Root
        {
            [XmlElement("Persons")]
            public List<Persons> Persons { get; set; }
        }
    
        public class Persons
        {
            public string IsMale { get; set; }
            public int Age { get; set; }
            public Persons LikedPerson { get; set; }
    
            [XmlAttribute("Name")]
            public string Name { get; set; }
        }
    }
