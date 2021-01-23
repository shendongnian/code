    public class ProperXmlNodeReader : XmlNodeReader
    {
        public ProperXmlNodeReader(XmlNode node) : base(node)
        {
        }
        public override string LookupNamespace(string prefix)
        {
            return NameTable.Add(base.LookupNamespace(prefix));
        }
    }
