    public  class Register
    {
        [Required(ErrorMessage = "please provide full name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "please provide your email")]
        [EmailAddress(ErrorMessage = "please enter valid email")]`
        public string email { get; set; }
        [Required(ErrorMessage = "please provide password")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "password must be 8 char long")]
        public string Password { get; set; }
        [CompareAttribute("Password", ErrorMessage = "confirm password does not match")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
