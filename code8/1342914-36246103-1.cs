    [XmlRoot(ElementName = "FlightSegment")]
    public class FlightSegment
    {
        [XmlElement(ElementName = "DepDate")]
        public string DepDate { get; set; }
        [XmlElement(ElementName = "DepTime")]
        public string DepTime { get; set; }
        [XmlElement(ElementName = "ArrDate")]
        public string ArrDate { get; set; }
        [XmlElement(ElementName = "ArrTime")]
        public string ArrTime { get; set; }
        [XmlElement(ElementName = "DepDay")]
        public string DepDay { get; set; }
        [XmlElement(ElementName = "ArrDay")]
        public string ArrDay { get; set; }
        [XmlElement(ElementName = "DepAirport")]
        public string DepAirport { get; set; }
        [XmlElement(ElementName = "DepAirportName")]
        public string DepAirportName { get; set; }
        [XmlElement(ElementName = "DepCityName")]
        public string DepCityName { get; set; }
        [XmlElement(ElementName = "ArrAirport")]
        public string ArrAirport { get; set; }
        [XmlElement(ElementName = "ArrAirportName")]
        public string ArrAirportName { get; set; }
        [XmlElement(ElementName = "ArrCityName")]
        public string ArrCityName { get; set; }
        [XmlElement(ElementName = "DepCountry")]
        public string DepCountry { get; set; }
        [XmlElement(ElementName = "ArrCountry")]
        public string ArrCountry { get; set; }
        [XmlElement(ElementName = "Airline")]
        public string Airline { get; set; }
        [XmlElement(ElementName = "AirName")]
        public string AirName { get; set; }
        [XmlElement(ElementName = "FlightNo")]
        public string FlightNo { get; set; }
        [XmlElement(ElementName = "BookingClass")]
        public string BookingClass { get; set; }
        [XmlElement(ElementName = "AirCraftType")]
        public string AirCraftType { get; set; }
        [XmlElement(ElementName = "ETicket")]
        public string ETicket { get; set; }
        [XmlElement(ElementName = "NonStop")]
        public string NonStop { get; set; }
        [XmlElement(ElementName = "DepTer")]
        public string DepTer { get; set; }
        [XmlElement(ElementName = "ArrTer")]
        public string ArrTer { get; set; }
        [XmlElement(ElementName = "AdtFareBasis")]
        public string AdtFareBasis { get; set; }
        [XmlElement(ElementName = "ChdFareBasis")]
        public string ChdFareBasis { get; set; }
        [XmlElement(ElementName = "InfFareBasis")]
        public string InfFareBasis { get; set; }
    }
    [XmlRoot(ElementName = "RecommendedSegment")]
    public class RecommendedSegment
    {
        [XmlElement(ElementName = "Duration")]
        public string Duration { get; set; }
        [XmlElement(ElementName = "FareBasis")]
        public string FareBasis { get; set; }
        [XmlElement(ElementName = "FlightSegment")]
        public List<FlightSegment> FlightSegment { get; set; }
        [XmlElement(ElementName = "DepAirport")]
        public string DepAirport { get; set; }
        [XmlElement(ElementName = "DepCity")]
        public string DepCity { get; set; }
        [XmlElement(ElementName = "DepCountry")]
        public string DepCountry { get; set; }
        [XmlElement(ElementName = "DepZone")]
        public string DepZone { get; set; }
        [XmlElement(ElementName = "ArrAirport")]
        public string ArrAirport { get; set; }
        [XmlElement(ElementName = "ArrCity")]
        public string ArrCity { get; set; }
        [XmlElement(ElementName = "ArrCountry")]
        public string ArrCountry { get; set; }
        [XmlElement(ElementName = "ArrZone")]
        public string ArrZone { get; set; }
    }
    [XmlRoot(ElementName = "Availability")]
    public class Availability
    {
        [XmlElement(ElementName = "RecommendedSegment")]
        public RecommendedSegment RecommendedSegment { get; set; }
    }
