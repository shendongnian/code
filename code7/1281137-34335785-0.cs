    public class Album
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string AlbumArtUrl { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
    }
    
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Album> Albums { get; set; }
    }
