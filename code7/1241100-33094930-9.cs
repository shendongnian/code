    [JsonConverter(typeof(JsonPathConverter))]
    class Person
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("age")]
        public int Age { get; set; }
        [JsonProperty("picture.data.url")]
        public string ProfilePicture { get; set; }
        [JsonProperty("favorites.movie")]
        public Movie FavoriteMovie { get; set; }
        [JsonProperty("favorites.color")]
        public string FavoriteColor { get; set; }
    }
    // Don't need to mark up these properties because they are covered by the 
    // property paths in the Person class
    class Movie
    {
        public string Title { get; set; }
        public int Year { get; set; }
    }
