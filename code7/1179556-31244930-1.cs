    public class LoginViewModel
    {
        [Required(ErrorMessage="*")]
        [StringLength(20, MinimumLength=5)]
        public string UserName { get; set; }
    
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
