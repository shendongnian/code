    public class SurgeryWriter : XmlTextWriter
    {
        public SurgeryWriter(string url) : base(url, Encoding.UTF8) { }
    
        private int counter = 1;
    
        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            if (localName == "surgery")
            {
                base.WriteStartElement(prefix, "surgery" + counter, ns);
                counter++;
            }
            else
                base.WriteStartElement(prefix, localName, ns);
        }
    }
    public class SurgeryReader : XmlTextReader
    {
        public SurgeryReader(string url) : base(url) { }
        public override string LocalName
        {
            get
            {
                if (base.LocalName.StartsWith("surgery"))
                    return "surgery";
                return base.LocalName;
            }
        }
    }
