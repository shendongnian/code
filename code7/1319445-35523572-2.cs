    public virtual Arena Arena { get; set; }
    
    public virtual Team HomeTeam { get; set; }
    [Required]
    [Range(0, 255)]
    public byte HomeTeamScore { get; set; }
    public virtual Team AwayTeam { get; set; }
    [Required]
    [Range(0, 255)]
    public byte AwayTeamScore { get; set; }
