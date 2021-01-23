    [XmlRoot("products")]
    public class Products
    {
        public Products()
        {
            Specifications = new Dictionary<string, string>();
        }
        [XmlIgnore]
        [JsonProperty("specifications")] // For testing purposes, I compare Json.NET serialization before and after XML serialization.  You can remove this.
        public Dictionary<string, string> Specifications { get; set; }
        [XmlElement("specifications")]
        [JsonIgnore] // For testing purposes, I compare Json.NET serialization before and after XML serialization.  You can remove this.
        public XmlKeyTextValueListWrapper<string> XmlSpecifications
        {
            get
            {
                return new XmlKeyTextValueListWrapper<string>(() => this.Specifications);
            }
            set
            {
                value.CopyTo(Specifications = (Specifications ?? new Dictionary<string, string>()));
            }
        }
    }
