    [XmlRoot("MyRoot", Namespace = XmlNamespace)]
    public class MyRoot
    {
        public const string XmlNamespace = "http://sample.com";
        [XmlArrayItem(Type = typeof(This))]
        [XmlArrayItem(Type = typeof(That))]
        public List<MyThing> Things { get; set; }
    }
    public class MyThing
    {
    }
    public class This : MyThing
    {
        public string ThisRef { get; set; }
    }
    public class That : MyThing
    {
        public string ThatRef { get; set; }
    }
