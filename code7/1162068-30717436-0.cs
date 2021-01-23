    public class Template
    {
        public string Id { get; set; }
        //other properties
        [JsonConverter(typeof(StringEnumConverter))]
        public Enum Status { get; set; }
    }
