    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [System.ComponentModel.DataAnnotations.Compare("Password",
                        ErrorMessage = "The password and confirmation password do not match.")]
    public string Name { get; set; }
