    var xml1 =
                "<?xml version=\"1.0\" encoding=\"utf-8\"?><foo:NameHent xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:foo1=\"http://sample.com\" xmlns:foo=\"http://example.com\"><foo1:Firstname>John</foo1:Firstname><foo1:Firstname>Michael</foo1:Firstname><foo1:Lastname>Doe</foo1:Lastname><foo1:Date>1988-03-05</foo1:Date></foo:NameHent>";
     XmlSerializer xmlSerializer = new XmlSerializer(typeof(NameHent));
            NameHent c = xmlSerializer.Deserialize(new StringReader(xml1)) as NameHent;
    [XmlRoot(ElementName = "person",Namespace = "http://example.com")]
    public class Person
    {
        [XmlElement(Namespace = "http://sample.com")]
        public string Firstname;
        [XmlElement(Namespace = "http://sample.com")]
        public string Lastname;
        [XmlElement(Namespace = "http://sample.com")]
        public string Date;
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
        public Person()
        {
            xmlns.Add("foo", "http://example.com");
            xmlns.Add("foo1", "http://sample.com");
        }
    }
