    public class ExcelResourceDto
    {
        [Column(0)]
        [Required]
        public string Title { get; set; }
        [Column(1)]
        [Required]
        public string SearchTags { get; set; }
    }
   
