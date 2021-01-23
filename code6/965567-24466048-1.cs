    [Table("Review")]
    public class Review
    {
        public int Id { get; set; }
        [Required]
        public PictureInfo PictureInfo { get; set; }
    }
