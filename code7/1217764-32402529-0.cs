    [Required(AllowEmptyStrings = true)]
    public string Password { get; set; }
    
    public string PasswordSalt { get; set; }
    
    [Required(AllowEmptyStrings = true)]
    [Display(Name = "Security Question")]
    public string SecurityQuestion { get; set; }
    
    [Required(AllowEmptyStrings = true)]
    [Display(Name = "Security Answer")]
    public string SecurityAnswer { get; set; }
