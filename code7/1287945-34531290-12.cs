    public class AlbumDetails
    {
       public DateTime AlbumDate { get; set; }
       public string AlbumName { get; set; }
    }
    public class AlbumMapper
    {
        public int SingerID { get; set; }
        public IEnumerable<AlbumDetails> Albums { get; set; }
    }
