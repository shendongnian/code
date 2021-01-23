    public class RootObject
    {
        [JsonProperty("value")]
        [JsonConverter(typeof(DictionaryToDictionaryListConverter<string, string>))]
        public Dictionary<string, string> Value { get; set; }
    }
