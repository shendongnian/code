    [ForeignKey("PeopleId")]
    public virtual PeopleView People { get; set; }
    [Required]
    public virtual int? PeopleId { get; set; }
    [ForeignKey("ProjectId")]
    public virtual ProjectView Project { get; set; } 
    [Required]
    public virtual string ProjectId { get; set; }
