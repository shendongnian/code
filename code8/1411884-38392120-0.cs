    public class CustomWriter : XmlTextWriter
    {
        public CustomWriter(TextWriter writer) : base(writer) { }
        public CustomWriter(Stream stream, Encoding encoding) : base(stream, encoding) { }
        public CustomWriter(string filename, Encoding encoding) : base(filename, encoding) { }
        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            base.WriteStartElement(prefix, localName, ns);
            if (localName == "CoreItemsMkt")
            {
                base.WriteAttributeString("xmlns",
                    "http://www.fsa.gov.uk/XMLSchema/FSAMarketsFeed-v1-2");
                //base.WriteAttributeString("xmlns", ns);
            }
        }
    }
