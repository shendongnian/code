    [DisplayName("Postal Address")]
    [Description("The mailing address.")]
    public class PostalAddress
    {
        [DisplayName("Street Address")]
        [Description("The street address. For example, 1600 Amphitheatre Pkwy.")]
        public string StreetAddress { get; set; }
    
        [DisplayName("Locality")]
        [Description("The locality. For example, Mountain View.")]
        public string AddressLocality { get; set; }
    
        [DisplayName("Region")]
        [Description("The region. For example, CA.")]
        public string AddressRegion { get; set; }
    
        [DisplayName("Country")]
        [Description("The country. For example, USA. You can also provide the two letter ISO 3166-1 alpha-2 country code.")]
        public string AddressCountry { get; set; }
    
        [DisplayName("Postal Code")]
        [Description("The postal code. For example, 94043.")]
        public string PostalCode { get; set; }
    }
