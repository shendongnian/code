    [Key]
    public int AdminID { get; set; }
        
    [ForeignKey("User")]
    public int UserID { get; set; } 
