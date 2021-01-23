        class MyDocument
        {
            [JsonProperty("theMovies")]
            public Movie[] Movies { get; set; }
        }
    You can then access the first item in `document.Movies`
