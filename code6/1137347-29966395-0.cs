    public class UserViewModel
    {
        public int UserId { get; set; }
        
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
        [Required]
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        
        [Required]
        [Display(Name="Last Name")]
        public string LastName { get; set; }
        
        public string Address { get; set; }
        
        [Required]
        [EmailValidator(ErrorMessage = "Email entered is not valid")]
        [Display(Name="Email")]
        public string Email { get; set; }
    }
