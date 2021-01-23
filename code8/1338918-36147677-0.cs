    public void Serialize(TextWriter textWriter, object o, XmlSerializerNamespaces namespaces) {
        XmlTextWriter xmlWriter = new XmlTextWriter(textWriter);
        xmlWriter.Formatting = Formatting.Indented;
        xmlWriter.Indentation = 2;
        Serialize(xmlWriter, o, namespaces);
    }
