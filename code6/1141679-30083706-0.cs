    //Other fields removed to save space
    [Required]
    [Display(Name = "Role")]
    public IdentityRole UserRole { get; set; }
    [Display(Name = "Roles")]
    public IEnumerable<IdentityRole> UserRoles { get; set; }
