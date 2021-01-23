    [XmlRoot(ElementName = "client-info", Namespace = "http://www.foo.com/schema/w/v1.0")]
    public class Clientinfo
    {
        [XmlElement(ElementName = "client-name", Namespace = "http://www.foo.com/schema/w/v1.0")]
        public string Clientname { get; set; }
        [XmlElement(ElementName = "w-id", Namespace = "http://www.foo.com/schema/w/v1.0")]
        public string Wid { get; set; }
    }
    [XmlRoot(ElementName = "transferee-name", Namespace = "http://www.foo.com/schema/w/v1.0")]
    public class Transfereename
    {
        [XmlElement(ElementName = "first", Namespace = "http://www.foo.com/schema/w/v1.0")]
        public string First { get; set; }
        [XmlElement(ElementName = "last", Namespace = "http://www.foo.com/schema/w/v1.0")]
        public string Last { get; set; }
    }
    [XmlRoot(ElementName = "spouse-name", Namespace = "http://www.foo.com/schema/w/v1.0")]
    public class Spousename
    {
        [XmlElement(ElementName = "first", Namespace = "http://www.foo.com/schema/w/v1.0")]
        public string First { get; set; }
        [XmlElement(ElementName = "last", Namespace = "http://www.foo.com/schema/w/v1.0")]
        public string Last { get; set; }
    }
    [XmlRoot(ElementName = "o-address", Namespace = "http://www.foo.com/schema/w/v1.0")]
    public class Oaddress
    {
        [XmlElement(ElementName = "street1", Namespace = "http://www.foo.com/schema/w/v1.0")]
        public string Street1 { get; set; }
        [XmlElement(ElementName = "city", Namespace = "http://www.foo.com/schema/w/v1.0")]
        public string City { get; set; }
        [XmlElement(ElementName = "state", Namespace = "http://www.foo.com/schema/w/v1.0")]
        public string State { get; set; }
        [XmlElement(ElementName = "postal-code", Namespace = "http://www.foo.com/schema/w/v1.0")]
        public string Postalcode { get; set; }
        [XmlElement(ElementName = "country", Namespace = "http://www.foo.com/schema/w/v1.0")]
        public string Country { get; set; }
    }
    [XmlRoot(ElementName = "d-address", Namespace = "http://www.foo.com/schema/w/v1.0")]
    public class Daddress
    {
        [XmlElement(ElementName = "street1", Namespace = "http://www.foo.com/schema/w/v1.0")]
        public string Street1 { get; set; }
        [XmlElement(ElementName = "city", Namespace = "http://www.foo.com/schema/w/v1.0")]
        public string City { get; set; }
        [XmlElement(ElementName = "state", Namespace = "http://www.foo.com/schema/w/v1.0")]
        public string State { get; set; }
        [XmlElement(ElementName = "postal-code", Namespace = "http://www.foo.com/schema/w/v1.0")]
        public string Postalcode { get; set; }
        [XmlElement(ElementName = "country", Namespace = "http://www.foo.com/schema/w/v1.0")]
        public string Country { get; set; }
    }
    [XmlRoot(ElementName = "phone", Namespace = "http://www.foo.com/schema/w/v1.0")]
    public class Phone
    {
        [XmlElement(ElementName = "phone-type", Namespace = "http://www.foo.com/schema/w/v1.0")]
        public string Phonetype { get; set; }
        [XmlElement(ElementName = "phone-number", Namespace = "http://www.foo.com/schema/w/v1.0")]
        public string Phonenumber { get; set; }
    }
    [XmlRoot(ElementName = "contact-info", Namespace = "http://www.foo.com/schema/w/v1.0")]
    public class Contactinfo
    {
        [XmlElement(ElementName = "phone", Namespace = "http://www.foo.com/schema/w/v1.0")]
        public List<Phone> Phone { get; set; }
        [XmlElement(ElementName = "email", Namespace = "http://www.foo.com/schema/w/v1.0")]
        public string Email { get; set; }
        [XmlElement(ElementName = "comments", Namespace = "http://www.foo.com/schema/w/v1.0")]
        public string Comments { get; set; }
    }
    [XmlRoot(ElementName = "customer", Namespace = "http://www.foo.com/schema/w/v1.0")]
    public class Customer
    {
        [XmlElement(ElementName = "client-info", Namespace = "http://www.foo.com/schema/w/v1.0")]
        public Clientinfo Clientinfo { get; set; }
        [XmlElement(ElementName = "transferee-name", Namespace = "http://www.foo.com/schema/w/v1.0")]
        public Transfereename Transfereename { get; set; }
        [XmlElement(ElementName = "spouse-name", Namespace = "http://www.foo.com/schema/w/v1.0")]
        public Spousename Spousename { get; set; }
        [XmlElement(ElementName = "o-address", Namespace = "http://www.foo.com/schema/w/v1.0")]
        public Oaddress Oaddress { get; set; }
        [XmlElement(ElementName = "d-address", Namespace = "http://www.foo.com/schema/w/v1.0")]
        public Daddress Daddress { get; set; }
        [XmlElement(ElementName = "contact-info", Namespace = "http://www.foo.com/schema/w/v1.0")]
        public Contactinfo Contactinfo { get; set; }
        [XmlAttribute(AttributeName = "w-number")]
        public string Wnumber { get; set; }
        [XmlAttribute(AttributeName = "customer-number")]
        public string Customernumber { get; set; }
    }
    [XmlRoot(ElementName = "customers", Namespace = "http://www.foo.com/schema/w/v1.0")]
    public class Customers
    {
        [XmlElement(ElementName = "customer", Namespace = "http://www.foo.com/schema/w/v1.0")]
        public Customer Customer { get; set; }
    }
    [XmlRoot(ElementName = "new-order", Namespace = "http://www.foo.com/schema/w/v1.0")]
    public class Neworder
    {
        [XmlElement(ElementName = "customers", Namespace = "http://www.foo.com/schema/w/v1.0")]
        public Customers Customers { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
        [XmlAttribute(AttributeName = "supplier-code")]
        public string Suppliercode { get; set; }
        [XmlAttribute(AttributeName = "schemaLocation")]
        public string SchemaLocation { get; set; }
    }
