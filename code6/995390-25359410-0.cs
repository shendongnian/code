    public XmlDocument LoadDocument(String x)
    {
        XmlDocument document = new XmlDocument();
        using (StreamReader stream = new StreamReader(xml, Encoding.GetEncoding("iso-8859-7")))
        {
            document.Load(stream);
        }
        return (document);
    }
    public XmlDocument SaveDocument(String x)
    {
        XmlDocument document = new XmlDocument();
        using (StreamWriter stream = new StreamWriter(x,false,Encoding.GetEncoding("iso-8859-7")))
        {
            document.Save(xml);
        }
        return (document);
    }
