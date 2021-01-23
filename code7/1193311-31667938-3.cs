    [InverseProperty("UserId ")]
    [ForeignKey("CreatedBy")]
    public User User { get; set; }
    [InverseProperty("UserId ")]
    [ForeignKey("ModifiedBy")]
    public User User1 { get; set; }
