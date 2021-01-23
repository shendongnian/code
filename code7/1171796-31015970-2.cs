    public class Person 
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public bool Deceased { get; set; }
    }
    public class Being
    {
        public string Data { get; set; }
        [XmlElement("Human")]
        public Person Human { get; set; }
        public bool ShouldSerializeHuman()
        {
            return !this.Human.Deceased;
        }
    }
