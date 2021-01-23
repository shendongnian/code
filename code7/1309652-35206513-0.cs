    var writer = new XmlTextWriter("output.xml", Encoding.UTF8)
    {
        Formatting = Formatting.Indented,
        Indentation = 1,
        IndentChar = '\t',
        Namespaces = true,
    };
    
    writer.WriteStartDocument();
    
    writer.WriteStartElement("RSIL", "Project", "http://www.url.com/RSIL");
    writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
    writer.WriteAttributeString("xmlns:eQ", "http://www.url.com/eQ");
    writer.WriteAttributeString("xsi:schemaLocation", "http://www.url.com/RSIL Name_RSIL.xsd");
    writer.WriteEndElement();
    
    writer.WriteEndDocument();
    
    writer.Flush();
    writer.Close();
