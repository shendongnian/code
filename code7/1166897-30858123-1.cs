    using System.Xml;
    using System.Xml.Serialization;
    using (StringReader stringReader = new StringReader(xmlString))
    using (XmlTextReader xmlTextReader = new XmlTextReader(stringReader) { Normalization = false })
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        item = (T)xmlSerializer.Deserialize(xmlTextReader);
    }
