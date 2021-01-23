    [XmlType("authorizations")]
    public class Authorization
    {
        [XmlElement("id")]
        public string Id { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlArray("Lists")]
        [XmlArrayItem("List")]
        public List[] Items { get; set; }
    }
    public class List
    {
        [XmlElement("id")]
        public string Id { get; set; }
    }
    public class AuthorizationList
    {
        [XmlElement("authorizations")]
        public Authorization[] Authorizations { get; set; }
    }
