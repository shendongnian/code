    [XmlRoot("MyRoot", Namespace = XmlNamespace)]
    public class MyRoot
    {
        public const string XmlNamespace = "http://sample.com";
        [XmlElement(Type=typeof(This))]
        [XmlElement(Type = typeof(That))]
        public List<MyThing> Things { get; set; }
    }
