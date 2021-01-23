	SecurityGroups deserialized;
    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(SecurityGroups));
    using (var stringReader = new System.IO.StringReader(xmlData))
    {
        deserialized = serializer.Deserialize(stringReader) as SecurityGroups;
    }
