    public XmlDocument ReadRawXml(HttpRequestMessage request)
    {
        var xmlDoc = new XmlDocument();
        xmlDoc.Load(request.Content.ReadAsStreamAsync().Result);
        return xmlDoc;
    }
