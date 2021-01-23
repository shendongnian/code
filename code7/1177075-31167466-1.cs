    public class AlbumViewModel
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string AlbumArtUrl { get; set; }
        public GenreViewModel Genre { get; set; }
        public ArtistViewModel Artist { get; set; }
    }
    public class ArtistViewModel
    {
        public string Name { get; set; }
        ...
    }
    public class GenreViewModel
    {
        ...
    }
