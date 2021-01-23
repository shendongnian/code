    public static OE DeserializeFragment(string xmlFragment)
    {
        var serializer = new System.Xml.Serialization.XmlSerializer(typeof(OE));
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xmlFragment);
            NameTable nt = new NameTable();
            XmlNamespaceManager nsManager = new XmlNamespaceManager(nt);
            nsManager.AddNamespace("one", "http://schemas.microsoft.com/office/onenote/2013/onenote");
            XmlParserContext context = new XmlParserContext(null, nsManager, null, XmlSpace.None);
            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
            xmlReaderSettings.ConformanceLevel = ConformanceLevel.Fragment;
            return ((OE)(serializer.Deserialize(System.Xml.XmlReader.Create(stringReader, xmlReaderSettings, context))));
        }
        finally
        {
            if ((stringReader != null))
            {
                stringReader.Dispose();
            }
        }
    }
