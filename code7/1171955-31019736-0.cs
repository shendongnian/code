    [Table("Files")]
    public class Files
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Display(Name = "FileID")]
        public int FileID { get; set; }
        [Required]
        
        [Display(Name = "For User")]
        public int UserId { get; set; }
        [Display(Name = "Description")]
        public string Desc { get; set; }
        [Required]
        [Display(Name = "Document Upload")]
        public string DocumentPath { get; set; }
        [ForeignKey("UserId")] // this is what I have tried
        public virtual UserProfile UserProfile { get; set; }
    }
