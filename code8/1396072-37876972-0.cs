    [Required]
    [StringLength(128)]
    public string UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual ApplicationUser AspNetUser { get; set; }
