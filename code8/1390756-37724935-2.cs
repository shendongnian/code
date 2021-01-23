    public class LoginViewModel {
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Speichern?")]
        public bool RememberMe { get; set; }
        [NonSerialized]
        public List<ApplicationUser> allUsers;
        [Required(ErrorMessage = "Please select your name")]
        public int? userid { get; set; }
    }
