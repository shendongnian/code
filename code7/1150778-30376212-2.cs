    public int PublicImageID { get; set; }
    [ForeignKey("PublicImageID")]
    public PublicImage PublicImage { get; set; }
    
    // Foreign Keys    
    public Guid OwnerId { get; set; }
    [ForeignKey("Owner")]
    public virtual Owner Owner { get; set; }
