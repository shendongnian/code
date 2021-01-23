    public class Movie
    {
        public string Name { get; set; }
        [JsonConverter(typeof(GenreConverter))]
        public Genre Genre { get; set; }
    }
