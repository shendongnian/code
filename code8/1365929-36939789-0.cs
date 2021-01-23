    using (XmlWriter writer = XmlWriter.Create(@"C:\\Test.XML"))
    {
        writer.WriteStartDocument();
        writer.WriteStartElement("Test");
        string scontent = "<A a=\"Hello\"></A><B b=\"Hello\"></B>";
        var settings = new XmlReaderSettings();
        settings.ConformanceLevel = ConformanceLevel.Fragment;
        using (StringReader stringReader = new StringReader(scontent))
        using (XmlReader xmlReader = XmlReader.Create(stringReader, settings))
        {
            writer.WriteNode(xmlReader, true);
        }
        writer.WriteEndElement();
    }
