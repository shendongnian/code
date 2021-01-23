    XmlWriter writer = XmlWriter.Create(@"C:\\Test.XML")
    writer.WriteStartDocument();
    writer.WriteStartElement("Test");
    
    string scontent = "<A a=\"Hello\"></A><B b=\"Hello\"></B>";
    XmlReader content = XmlReader.Create(new StringReader(scontent));
    writer.WriteNode(content, true);
    //Here only my first node comes in the new XML but I want complete scontent
    writer.WriteEndElement();
