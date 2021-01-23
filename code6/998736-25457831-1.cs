    public class Track
    {
        public string Title { get; set; }
        public string DisplayTitle { get; set; }
        public int Year { get; set; }
        public int Duration { get; set; }
        public int? TrackNumber { get; set; }
        [JsonConverter(typeof(BaseTypeConverter<ArtistInfo>))]
        public ArtistInfo Artist { get; set; }
    }
