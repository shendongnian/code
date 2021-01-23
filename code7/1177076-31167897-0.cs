    public class AlbumViewModel
    {
        public int AlbumId { get; set; }
        
        public AlbumGenre Genre { get; set; }
        public AlbumArtist Artist { get; set; }
    
    }
    
    [MetadataType(typeof(AlbumArtistMetadata))]
    public class AlbumArtist : Artist {
        private class AlbumArtistMetadata {
            [Display(Name="Artist Name")]
            public string Name { get; set; }
        }
    }
    
    [MetadataType(typeof(AlbumGenreMetadata))]
    public class AlbumGenre : Genre
    {
        private class AlbumGenreMetadata
        {
            [Display(Name = "Genre Name")]
            public string Name { get; set; }
        }
    }
