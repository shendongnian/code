    public class PostalAddress
    {
        public string DeliverTo { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public Country Country { get; set; }
        
    }
    public class Country
    {
        [XmlAttribute("isoCountryCode")]
        public string CountryCode { get; set; }
        [XmlText]
        public string Description { get; set; }
    }
