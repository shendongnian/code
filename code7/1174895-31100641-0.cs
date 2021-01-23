    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    [Required]
    public String Email { get; set; }
    [Required]
    public String Password { get; set; }
    public String FirstName { get; set; }
    [Required]
    public String LastName { get; set; }
    [Required]
    public String ImageUrl{ get; set; }
