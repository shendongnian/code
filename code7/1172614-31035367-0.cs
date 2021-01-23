    public class PostalAddress
    {
        public string DeliverTo { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }    
        public Country Country { get; set; }
    }
    
    [XmlRoot("Country")]
    public class Country 
    {
        [XmlAttribute("isoCountryCode")]
        public string IsoCountryCode { get; set;}
        [XmlText]
        public string Name { get; set; }
    }
