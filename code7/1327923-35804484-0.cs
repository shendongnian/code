    public class Project
    {
        public int Id { get; set; }
    
        [Required]
        [StringLength(100, MinimumLength = 5]
        public string Name { get; set; }
    
        [Required]
        public virtual ApplicationUser Client { get; set; }
    
    
        [ForeignKey("Client")]
        public string ClientID{ get; set; } //<--fixed 
    
    
        [Required]
        public virtual ApplicationUser ProjectManager { get; set; }
    
    
        [ForeignKey("ProjectManager")]
        public string ProjectManagerID { get; set; } //<--fixed 
    
        [Range(0,100)]
        [Required]
        public int Progress { get; set; }
    
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }
    
        [Column("Disabled")]
        public bool Disabled{ get; set; }
    
        [Column("Status")]
        public string Status{ get; set; }
    
    }
