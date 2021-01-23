    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        [XmlAttribute("recordId")]
        public int recordId { get; set; }
    }
