    public class StringDictionaryWrapper
    {
        public StringDictionaryWrapper()
        {
            Items = new Dictionary<string, object>();
        }
        // Holds the value of the item with a null key, if any.
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public object NullItem { get; set; }
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public Dictionary<string, object> Items { get; set; }
    }
