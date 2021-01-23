    class Person
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("age")]
        public string Age { get; set; }
        public string ProfilePicture { get; set; }
    }
