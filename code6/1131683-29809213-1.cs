    public static class XmlKeyTextValueListWrapperExtensions
    {
        public static void ClearAndAddRange<TValue>(this IDictionary<string, TValue> dictionary, XmlKeyTextValueListWrapper<TValue> collection)
        {
            if (collection.IsWrapperFor(dictionary)) // For efficiency
                return;
            var pairs = collection.ToList();
            dictionary.Clear();
            foreach (var item in pairs)
                dictionary.Add(item.Key, item.Value);
        }
    }
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
                (Specifications = (Specifications ?? new Dictionary<string, string>())).ClearAndAddRange(value);
            }
        }
    }
