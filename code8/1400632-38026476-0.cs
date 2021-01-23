    public class Movie
        {
            public int ID { get; set; }
    
             [StringLength(60, MinimumLength = 3)]
            public string Title { get; set; }
    
             [Required]  
            [Display(Name = "Release Date")]
            //[DataType(DataType.Date)]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
            public DateTime ReleaseDate { get; set; }
    
           .....
        }
