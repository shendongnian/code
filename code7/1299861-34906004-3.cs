    public class Group
    {
        [JsonProperty(ItemConverterType = typeof(AutoInterningStringConverter))]
        public List<string> StandardStrings { get; set; }
    }
