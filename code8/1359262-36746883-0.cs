    public class Album
    {
        public int AlbumId { get; set; }
        public Stamp Stamp { get; set; }
        // other properties
    }
 
    public class Stamp
    {
        [Index(IsUnique = true)] // another UID, just to follow the naming pattern        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StampId { get; set; }
        [Key, ForeignKey("Album")] // The PK, taken as FK from the associated Album
        public int AlbumId { get; set; }
        [Required] // the required attribute just makes validation errors more readable
        public Album Album { get; set; }
        // other properties
    }
