    [Required(ErrorMessage = "you must enter firstname")]
    public string name { get; set; }
    [EmailAddress(ErrorMessage = "enter valid email")]
    public string email { get; set; }
    [Required(ErrorMessage = "you must your age")]
    [Range(18, 70, ErrorMessage = "age must be from 18 : 70")]
    public int age { get; set; }
