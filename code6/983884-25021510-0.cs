    XmlTextWriter writer = new XmlTextWriter("filename",System.Text.Encoding.UTF8);                  writer.WriteStartDocument(True)
        writer.WriteStartElement("Start Element Name")
        createNode("NodeName", writer)
        writer.WriteEndElement()
        writer.WriteEndDocument()
        writer.Close()
    public void createnode(String nodename, XmlTextWriter writer)
    {
        writer.WriteStartElement("Name Here")
        writer.WriteString(nodename)
        writer.WriteEndElement()
    }
