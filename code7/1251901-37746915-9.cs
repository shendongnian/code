    public class ExcelResourceDto
    {
        [Column(1)]
        [Required]
        public string Title { get; set; }
        [Column(2)]
        [Required]
        public string SearchTags { get; set; }
    }
   
