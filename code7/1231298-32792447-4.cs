    public class Request
    {
        public string SName { get; set; }
        public Message Message { get; set; }
    }
    public static class Namespaces
    {
        public const string pd = "http://pd.com";
        public const string a = "http://www.a.com";
        public const string z = "http://www.z.com";
        public static XmlSerializerNamespaces GetNamespaces()
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("pd", pd);
            ns.Add("a", a);
            ns.Add("z", z);
            return ns;
        }
    }
    public class Message
    {
        [XmlIgnore]
        public AddO AddO { get; set; }
        // Do nested serialization here
        [XmlAnyElement]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public XElement[] AddOXml
        {
            get
            {
                if (AddO == null)
                    return null;
                var ns = Namespaces.GetNamespaces();
                var element = AddO.SerializeToXElement(ns);
                element.Name = element.Name.Namespace + "addO";
                return new[] { element };
            }
            set
            {
                if (value == null || value.Length == 0)
                    AddO = null;
                AddO = value.Select(x => { x.Name = x.Name.Namespace + "AddO"; return x.Deserialize<AddO>(); }).FirstOrDefault();
            }
        }
    }
    [XmlRoot(Namespace = Namespaces.pd)]
    public class AddO
    {
        [XmlElement("caseD", Namespace = Namespaces.a )]
        public CaseD CaseD { get; set; }
    }
    public class CaseD
    {
        [XmlElement("caseA", Namespace = Namespaces.z)]
        public CaseA CaseA { get; set; }
    }
    public class CaseA
    {
        public string Value { get; set; }
    }
