    class MovieJsonWrapper
    {
        [JsonProperty("movie")]
        public Movie Movie { get; set; }
    }
    class Movie
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    
        [JsonProperty("genre")]
        public Genre Genre { get; set; }
    }
    class Genre
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    
        [JsonProperty("name")]
        public string Name { get; set; }
    }
