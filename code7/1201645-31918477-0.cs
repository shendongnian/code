    [XmlRoot(ElementName = "YourCustomClassName")]
    public class GetDetailsFromCardNumberResponse
    {
        [XmlElement(ElementName = "YourCustomAttibuteName")]
        public PatronAccountCardValidation PatronValidation { get; set; }
    }
