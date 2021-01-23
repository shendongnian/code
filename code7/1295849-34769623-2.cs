    public Int16? ApprovedByID { get; set; }
    public Int16 AssignedToID { get; set; }
    public Int16 CreatedByID { get; set; }
    // navigation properties
    [ForeignKey("ApprovedByID")]
    public User ApprovedBy { get; set; }
    [ForeignKey("AssignedToID")]
    public User AssignedTo { get; set; }
    [ForeignKey("CreatedByID")]
    public User CreatedBy { get; set; }
