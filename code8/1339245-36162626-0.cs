    [XmlRoot("TimeStamp", Namespace = TimeStamp.WsuNamespace)]
    public class TimeStamp
    {
        public const string WsuNamespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd";
        public TimeStamp()
        {
            Id = "TimeStamp-2";
            Created = new Created() { Value = Created.GenerateTimeStampCreation() };
            Expires = new Expires() { Value = Expires.GenerateTimeStampExpiration() };
        }
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)] // Indicates this attribute is explicitly in the same namespace as the parent class
        public string Id { get; set; }
        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] // Indicates this element is not in any namespace
        public Created Created { get; set; }
        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] // Indicates this element is not in any namespace
        public Expires Expires { get; set; }
    }
