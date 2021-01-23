	public class RegistrationViewModel
	{
        [Required]
        [DataType(DataType.EmailAddress)]
		public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")
		public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }
	}
