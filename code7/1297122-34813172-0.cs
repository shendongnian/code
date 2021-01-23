    [XmlType(Namespace="", TypeName="root")]
    public class PersonCollection
    {
        [XmlElement(Namespace="", ElementName="Persons")]
        public List<Persons> People { get; set; }
    }
    public class Persons
    {
        [XmlAttribute(AttributeName="name")]
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsMale { get; set; }
        
        public Persons LikedPerson { get; set; }
        public Persons() { }
        public Persons(string name, int age, bool isMale, Persons likedPerson)
        {
            Name = name;
            Age = age;
            IsMale = isMale;
            LikedPerson = likedPerson;
        }
    }
