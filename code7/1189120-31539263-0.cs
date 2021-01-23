    public class Forwarded
    {
        [XmlElement(ElementName = "delay", Namespace = "urn:xmpp:delay")]
        public Delay Delay { get; set; }
        [XmlElement(ElementName = "message")]
        public XmppMessage Message { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
    }
    public class Result
    {
        [XmlElement(ElementName = "forwarded", Namespace = "urn:xmpp:forward:0")]
        public Forwarded Forwarded { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }
    [XmlRoot(ElementName = "message")]
    public class MessageHistory
    {
        [XmlElement(ElementName = "result", Namespace = "urn:xmpp:mam:tmp")]
        public Result Result { get; set; }
        [XmlAttribute(AttributeName = "from")]
        public string From { get; set; }
        [XmlAttribute(AttributeName = "to")]
        public string To { get; set; }
    }
