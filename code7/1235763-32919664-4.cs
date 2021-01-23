    public class MyXmlTextWriter : XmlTextWriter
    {
        public MyXmlTextWriter(TextWriter w)
            : base(w)
        {
        }
        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            base.WriteStartElement(prefix, localName, ns);
            switch(localName)
            {
                case "ISBN":
                    WriteAttributeString("friendlyName", "International Standard Book Number");
                    break;
            }
        }
    }
