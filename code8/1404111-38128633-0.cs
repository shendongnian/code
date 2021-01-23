    [XmlInclude(typeof(LossIncurredPayload))]
    public class RequestPayload
    {
        [XmlElement]
        public List<Payload> BOM_Request { get; set; }
    }
