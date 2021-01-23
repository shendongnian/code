    try
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("xml.xml");
        string XML = xmlDoc.InnerXml.ToString();
        byte[] BUFXML = ASCIIEncoding.UTF8.GetBytes(XML);
        MemoryStream ms1 = new MemoryStream(BUFXML);
        XmlSerializer DeserializerPlaces = new XmlSerializer(typeof(Sheet));
        using (XmlReader reader = new XmlTextReader(ms1))
        {
            Sheet dezerializedXML = (Sheet)DeserializerPlaces.Deserialize(reader);
        }// Put a break-point here, then mouse-over dezerializedXML and you should have you values
    }
    catch (System.Exception)
    {
        throw;
    }
