    using (StringReader stringReader = new StringReader(xmlString))
    using (XmlTextReader xmlTextReader = new XmlTextReader(stringReader) { Normalization = false })
    {
        System.Xml.Serialization.XmlSerializer xmlSerializer =
        new System.Xml.Serialization.XmlSerializer(typeof(T));
        item = (T)xmlSerializer.Deserialize(xmlTextReader);
    }
