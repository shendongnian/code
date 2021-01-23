    public class MyJsonDocument
    {
        //  JsonProperty indicates how each variable appears in the JSON, _
        //  so the deserializer knows that "theMovies" should be mapped to "Movies". _
        //  Alternatively, your C# vars should have the same name as the JSON vars.
        [JsonProperty("theMovies")]
        public List<Movie> Movies { get; set; }
    }
    public class Movie
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("year")]
        public int Year { get; set; }
    }
