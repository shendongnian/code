    public class Login
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email address cannot be empty!")]
        [MinLength(5)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
