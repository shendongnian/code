    public class Value
    {
        [JsonProperty(PropertyName = "text")]
        public string Text{ get; set; }
        [JsonProperty(PropertyName = "markup")]
        public IEnumerable<Markup> Markup {get; set; }
    }
