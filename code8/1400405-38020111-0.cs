    public class NilIgnoreReader : XmlTextReader
    {
        public NilIgnoreReader(string url) : base(url) { }
        bool isLocation = false;
        public override bool Read()
        {
            bool read = base.Read();
            if (NodeType == XmlNodeType.Element && LocalName == "location")
                isLocation = true;
            return read;
        }
        public override string GetAttribute(string localName, string namespaceURI)
        {
            if (localName == "nil" && namespaceURI == "http://www.w3.org/2001/XMLSchema-instance" && isLocation)
            {
                isLocation = false;
                return "false";
            }
            return base.GetAttribute(localName, namespaceURI);
        }
    }
