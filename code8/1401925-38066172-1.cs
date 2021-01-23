    class Foo
    {
        [JsonProperty("files")]
        [JsonConverter(typeof(RemoveDuplicatesConverter<string>))]
        public string[] Files { get; set; }
    }
