    public abstract class Response
    {
        [XmlElement("header")]
        public HeaderResponse Header { get; set; }
        public Response()
        {
        }
    }
