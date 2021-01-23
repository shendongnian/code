    public class RegisterViewModel
    {
        public string Name { get; set; }
        [Required(ErrorMessage = "please fill Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "please fill Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "please fill ConfirmPassword")]
        [Compare("Password", ErrorMessage = "...")]
        public string ConfirmPassword { get; set; }
    }
