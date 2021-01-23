    [Table("Review")]
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public PictureInfo PictureInfo { get; set; }
    }
    [Table("Review")]
    public class PictureInfo
    {
        [Key]
        public int Id { get; set; }
        public Review Review { get; set; }
    }
