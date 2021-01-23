    using System.Xml;
    using System.Xml.Serialization;
    using (var stringReader = new StringReader(xmlString))
    using (var xmlTextReader = new XmlTextReader(stringReader) { Normalization = false })
    {
        var xmlSerializer = new XmlSerializer(typeof(T));
        item = (T)xmlSerializer.Deserialize(xmlTextReader);
    }
