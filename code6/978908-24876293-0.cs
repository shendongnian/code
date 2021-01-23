    [XmlRoot("CONTACT")]
    [XmlInclude(typeof(CR.Models.XactAnalysis.Phone))]
    [XmlInclude(typeof(CR.Models.XactAnalysis.Email))]
    public class Contact
    {
        [XmlArray("CONTACTMETHODS")]
        public List<ContactMethod> ContactMethods { get; set; }
    }
    public class ContactMethod
    {
        [XmlElement("PHONE")]
        public Phone Phone { get; set; }
        [XmlElement("EMAIL")]
        public Email Email { get; set; }
    }
    [XmlRoot("PHONE")]
    public class Phone
    {
        [XmlAttribute("number")]
        public string Number { get; set; }
    }
    [XmlRoot("EMAIL")]
    public class Email
    {
        [XmlAttribute("address")]
        public string Address { get; set; }
    }
