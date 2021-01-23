    [XmlRoot(Namespace = "http://kmd.dk/fie/external_invoiceDistribution", IsNullable = false)]
    public class InvoiceChangeRequest
    {
        [XmlElement("CONTROL_FIELDS", Namespace = "")]
        public ControlFields Styrefelter { get; set; }
        [XmlElement("HEADER_IN", Namespace = "")]
        public HeaderIn HeaderfelterInd { get; set; }
        [XmlElement("ITEMS", Namespace = "")]
        public Items Linjer { get; set; }
    }
