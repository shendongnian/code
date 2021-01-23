    public class AvailabilityResponse
    {
        public string ApiKey { get; set; }
        public string ResellerId { get; set; }
        public string SupplierId { get; set; }
        public string ForeignReference { get; set; }
        public DateTime Timestamp { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public string TTAsku { get; set; }
        [XmlElement("TourAvailability")]
        public TourAvailability[] TourAvailability { get; set; }
    }
