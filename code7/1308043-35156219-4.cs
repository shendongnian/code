    public class GenreArtist
    {
        [Key,Column(Order=1), ForeignKey("Artist")]
        public string ArtistId { get; set; }
    
        [Key,Column(Order=2), ForeignKey("Genre")]
        public int GenreId { get; set; }
      
        public virtual Artist Artist { get; set; }
        public virtual Genre Genre { get; set; }
    }
