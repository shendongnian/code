    public class ContactDetails
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        [XmlArray("PhoneNumbers")]
        [XmlArrayItem("PhoneNumber")]
        public List<string> PhoneNumber { get; set; }
    }
