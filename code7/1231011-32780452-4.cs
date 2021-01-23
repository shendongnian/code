    public void UpdateXMLSerialize(List<Serialization> objXmlData)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Serialization>));
        using (TextWriter writer = new StreamWriter(xmlPath))
        {
            serializer.Serialize(writer, objXmlData);
        }
    }
