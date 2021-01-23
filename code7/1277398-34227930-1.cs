    [XmlRoot(ElementName = "CreateContact", Namespace = "http://foo.co.uk")]
    public class CreateContact
    {
        [XmlElement(ElementName = "contact")]
        public Contact Contact { get; set; }
    }
    
    [XmlRoot("contact", Namespace = "http://foo.co.uk/Contact")]
    public class Contact
    {
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Title { get; set; }
    }
