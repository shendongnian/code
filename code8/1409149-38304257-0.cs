    [XmlRoot("transport-agreements")]
    public class TransportAgreementRoot
    {
        [XmlElement("transport-agreement")]
        public TransportAgreement[] TransportAgreements { get; set; }
    }
    [XmlRoot("transport-agreement")]
    public class TransportAgreement
    {
        [XmlElement("description")]
        public string Description { get; set; }
        [XmlElement("id")]
        public int Id { get; set; }
        // other properties
    }
