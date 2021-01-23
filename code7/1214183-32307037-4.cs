    public class PrefixSelectingXmlWriterProxy : XmlWriterProxy
    {
        readonly Stack<XName> elements = new Stack<XName>();
        readonly Func<string, string, string, Stack<XName>, string> attributePrefixMap;
        public PrefixSelectingXmlWriterProxy(XmlWriter baseWriter, Func<string, string, string, Stack<XName>, string> attributePrefixMap)
            : base(baseWriter)
        {
            if (attributePrefixMap == null)
                throw new NullReferenceException();
            this.attributePrefixMap = attributePrefixMap;
        }
        public override void WriteStartAttribute(string prefix, string localName, string ns)
        {
            prefix = attributePrefixMap(prefix, localName, ns, elements);
            base.WriteStartAttribute(prefix, localName, ns);
        }
        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            base.WriteStartElement(prefix, localName, ns);
            elements.Push(XName.Get(localName, ns));
        }
        public override void WriteEndElement()
        {
            base.WriteEndElement();
            elements.Pop(); // Pop after base.WriteEndElement() lets the base class throw an exception on a stack error.
        }
    }
