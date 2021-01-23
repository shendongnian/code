    public class Property
    {
        [JsonProperty("alias")]
        public string Alias { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
    public class Fieldset
    {
        [JsonProperty("properties")]
        public Property[] Properties { get; set; }
        [JsonProperty("alias")]
        public string Alias { get; set; }
        [JsonProperty("disabled")]
        public bool Disabled { get; set; }
    }
    public class Response
    {
        [JsonProperty("fieldsets")]
        public Fieldset[] Fieldsets { get; set; }
    }
