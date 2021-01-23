    using(XmlWriter writer = XmlWriter.Create("output.xml"))
    {
        writer.WriteStartElement("Document");
        writer.WriteStartElement("Header");
        
        writer.WriteStartElement("OrgName");
        writer.WriteString("abc");
        writer.WriteEndElement();
        writer.WriteStartElement("OrgAddress");
        writer.WriteString("asd dfs 999 dfsd");
        writer.WriteEndElement();
        // End Header
        writer.WriteEndElement();
        writer.WriteStartElement("Detail");
        writer.WriteStartElement("EmpId");
        writer.WriteString("100");
        writer.WriteEndElement();
        // End Detail
        writer.WriteEndElement();
        // End Document
        writer.WriteEndElement();
    }
