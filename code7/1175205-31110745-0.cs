    public int StudentID { get; set; }
    [StringLength(50)]
    public string LastName { get; set; }
    [StringLength(50)]
    public string FirstName { get; set; }
    public Nullable<System.DateTime> EnrollmentDate { get; set; }
    [StringLength(50)]
     public string MiddleName { get; set; }
