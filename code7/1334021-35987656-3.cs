    [ForeignKey("Primary")]
    public int? PrimaryEngId { get; set; }
    [ForeignKey("Assigned")]    
    public int? AssignedDevloperId { get; set; }
    public virtual Engineer Primary { get; set; }
    
    public virtual Engineer Assigned { get; set; }
