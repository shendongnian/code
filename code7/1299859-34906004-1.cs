    public class Group
    {
        [JsonProperty(ItemConverterType = typeof(InternedStringConverter))]
        public List<string> StandardStrings { get; set; }
    }
