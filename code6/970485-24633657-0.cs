    public class NoNameSpaceXmlWriter : XmlTextWriter
    {
        public NoNameSpaceXmlWriter(TextWriter output) : base(output) { Formatting = Formatting.Indented; }
        public override void WriteStartDocument() { }
        public override void WriteStartElement(string prefix, string localName, string ns) { base.WriteStartElement("", localName, ""); }
    }
