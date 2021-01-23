    [Table("Review")]
    public class Review
    {
        [Key, ForeignKey("PictureInfo")]
        public int Id { get; set; }
        public PictureInfo PictureInfo { get; set; }
    }
    [Table("Review")]
    public class PictureInfo
    {
        [Key, ForeignKey("Review")]
        public int Id { get; set; }
        public Review Review { get; set; }
    }
