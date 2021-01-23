    [Serializable]
    [XmlRoot("serverData")]
    public class ServerData
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("number")]
        public int Number { get; set; }
        [XmlElement("language")]
        public string Language { get; set; }
        [XmlElement("timezone")]
        public string Timezone { get; set; }
        /* ... */
    }
    XmlSerializer xmlSerializer = new XmlSerializer(typeof(ServerData));
    using (Stream s = GenerateStreamFromString(Request.request(URL)))
    {
        xmlSerializer.Deserialize(s);
    }
