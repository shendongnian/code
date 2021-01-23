    [XmlRoot(ElementName = "MarketData")]
    public class MarketData
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "Price")]
        public string Price { get; set; }
        [XmlElement(ElementName = "CurrencySymbol")]
        public string CurrencySymbol { get; set; }
        [XmlElement(ElementName = "CurrencyCode")]
        public string CurrencyCode { get; set; }
        [XmlAttribute(AttributeName = "lang", Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Lang { get; set; }
    }
    [XmlRoot(ElementName = "App")]
    public class App
    {
        [XmlElement(ElementName = "AppId")]
        public string AppId { get; set; }
        [XmlElement(ElementName = "LinkUri")]
        public string LinkUri { get; set; }
        [XmlElement(ElementName = "CurrentMarket")]
        public string CurrentMarket { get; set; }
        [XmlElement(ElementName = "AgeRating")]
        public string AgeRating { get; set; }
        [XmlElement(ElementName = "MarketData")]
        public MarketData MarketData { get; set; }
        [XmlElement(ElementName = "IsActive")]
        public string IsActive { get; set; }
        [XmlElement(ElementName = "IsTrial")]
        public string IsTrial { get; set; }
    }
    [XmlRoot(ElementName = "Product")]
    public class Product
    {
        [XmlElement(ElementName = "MarketData")]
        public MarketData MarketData { get; set; }
        [XmlAttribute(AttributeName = "ProductId")]
        public string ProductId { get; set; }
        [XmlElement(ElementName = "IsActive")]
        public string IsActive { get; set; }
    }
    [XmlRoot(ElementName = "ListingInformation")]
    public class ListingInformation
    {
        [XmlElement(ElementName = "App")]
        public App App { get; set; }
        [XmlElement(ElementName = "Product")]
        public Product Product { get; set; }
    }
    [XmlRoot(ElementName = "LicenseInformation")]
    public class LicenseInformation
    {
        [XmlElement(ElementName = "App")]
        public App App { get; set; }
        [XmlElement(ElementName = "Product")]
        public Product Product { get; set; }
    }
    [XmlRoot(ElementName = "CurrentApp")]
    public class CurrentApp
    {
        [XmlElement(ElementName = "ListingInformation")]
        public ListingInformation ListingInformation { get; set; }
        [XmlElement(ElementName = "LicenseInformation")]
        public LicenseInformation LicenseInformation { get; set; }
    }
