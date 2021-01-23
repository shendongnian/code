    public class Book
    {
        [Display(Name = "Id:")]
        [Key]
        public int BookId { get; set; }
        [Display(Name = "Title:")]
        [MaxLength(35)]
        [Required]
        private string Title { get; set; }
        [Display(Name = "Description:")]
        [MaxLength(300)]
        private string Description { get; set; }
    }
