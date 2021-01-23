    public string XmlUnescape(string escaped)
    {
        XmlDocument doc = new XmlDocument();
        XmlNode node = doc.CreateElement("root");
        node.InnerXml = escaped;
        return node.InnerText;
    }
