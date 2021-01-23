    public class PostalAddress
    {
        public string DeliverTo { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    
        [XmlElement("Country")]
        public CountryCode CountryCode;
    }
    
    public class CountryCode
    {
        [XmlAttribute("isoCountryCode")]
        public string Code { get; set; }
    	[XmlText]
        public string Country { get; set; }
    }
