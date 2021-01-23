    var settings = new XmlReaderSettings() {
        NameTable = new NameTable(),
        ConformanceLevel = ConformanceLevel.Fragment
    };
    var nsmgr = new XmlNamespaceManager(settings.NameTable);
    nsmgr.AddNamespace("MyNamespace", "http://exemple.com");
    var context = new XmlParserContext(null, nsmgr, null, XmlSpace.Default);
    var reader = XmlReader.Create(stream, settings, context );
