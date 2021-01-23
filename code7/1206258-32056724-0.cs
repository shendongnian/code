    public class LoginViewModel
    {
       [Required]
       [Display(Name = "User name")]
       public string UserName {get; set;}
       [Required]
       [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
       [DataType(DataType.Password)]
       public string Password {get; set;}
    }
