    class Entity
    {
        [JsonProperty("ref")]
        public int @ref { get; set; }
        public string name { get; set; }
        public int year { get; set; }
    }
    var result = JsonConvert.DeserializeObject<List<Entity>>(jsonString);
