    public static class XmlNodeExtensions
    {
        public static T Deserialize<T>(this XmlNode element, XmlSerializer serializer = null)
        {
            using (var reader = new ProperXmlNodeReader(element))
                return (T)(serializer ?? new XmlSerializer(typeof(T))).Deserialize(reader);
        }
        class ProperXmlNodeReader : XmlNodeReader
        {
            // Bug fix from https://stackoverflow.com/questions/30102275/deserialize-object-property-with-stringreader-vs-xmlnodereader
            public ProperXmlNodeReader(XmlNode node)
                : base(node)
            {
            }
            public override string LookupNamespace(string prefix)
            {
                return NameTable.Add(base.LookupNamespace(prefix));
            }
        }
    }
