    // This class implements the LocalName override
    private class CustomXmlReader : CustomXmlReaderBase
    {
        // constructor
        public CustomXmlReader(XmlReader inner)
            : base(inner)
        {
        }
        // LocalName override
        public override string LocalName
        {
            get { return base.LocalName.StartsWith("entry") ? "entry" : base.LocalName; }
        }
    }
    // This class implements base behavior for an XML reader that wraps another XML reader.
    private abstract class CustomXmlReaderBase : XmlReader
    {
        protected CustomXmlReaderBase(XmlReader inner)
        {
            _inner = inner;
        }
        private readonly XmlReader _inner;
        public override string GetAttribute(string name)
        {
            return _inner.GetAttribute(name);
        }
        public override string GetAttribute(string name, string namespaceURI)
        {
            return _inner.GetAttribute(name, namespaceURI);
        }
        public override string GetAttribute(int i)
        {
            return _inner.GetAttribute(i);
        }
        public override bool MoveToAttribute(string name)
        {
            return _inner.MoveToAttribute(name);
        }
        public override bool MoveToAttribute(string name, string ns)
        {
            return _inner.MoveToAttribute(name, ns);
        }
        public override bool MoveToFirstAttribute()
        {
            return _inner.MoveToFirstAttribute();
        }
        public override bool MoveToNextAttribute()
        {
            return _inner.MoveToNextAttribute();
        }
        public override bool MoveToElement()
        {
            return _inner.MoveToElement();
        }
        public override bool ReadAttributeValue()
        {
            return _inner.ReadAttributeValue();
        }
        public override bool Read()
        {
            return _inner.Read();
        }
        public override string LookupNamespace(string prefix)
        {
            return _inner.LookupNamespace(prefix);
        }
        public override void ResolveEntity()
        {
            _inner.ResolveEntity();
        }
        public override XmlNodeType NodeType
        {
            get { return _inner.NodeType; }
        }
        public override string LocalName
        {
            get { return _inner.LocalName; }
        }
        public override string NamespaceURI
        {
            get { return _inner.NamespaceURI; }
        }
        public override string Prefix
        {
            get { return _inner.Prefix; }
        }
        public override string Value
        {
            get { return _inner.Value; }
        }
        public override int Depth
        {
            get { return _inner.Depth; }
        }
        public override string BaseURI
        {
            get { return _inner.BaseURI; }
        }
        public override bool IsEmptyElement
        {
            get { return _inner.IsEmptyElement; }
        }
        public override int AttributeCount
        {
            get { return _inner.AttributeCount; }
        }
        public override bool EOF
        {
            get { return _inner.EOF; }
        }
        public override ReadState ReadState
        {
            get { return _inner.ReadState; }
        }
        public override XmlNameTable NameTable
        {
            get { return _inner.NameTable; }
        }
    }
