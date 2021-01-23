    [Display(Name = "New Password")]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; }
    
    [Display(Name = "Confirm Password")]
    [DataType(DataType.Password)]
    [Compare("NewPassword")]
    public string PasswordConfirmation { get; set; }
