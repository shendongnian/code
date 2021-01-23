    [Serializable, XmlRoot(ElementName = "HotelListResponse", Namespace = "http://v3.hotel.wsapi.ean.com/")]
        public class HotelListResponse
        {
            [XmlElement(ElementName = "customerSessionId", Namespace = "")]
            public string customerSessionId { get; set; }
            [XmlElement(ElementName = "numberOfRoomsRequested", Namespace = "")]
            public int numberOfRoomsRequested { get; set; }
            [XmlElement(ElementName = "moreResultsAvailable", Namespace = "")]
            public bool moreResultsAvailable { get; set; }
        }
