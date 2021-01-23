        [Required]
        [DataType(DataType.Text)]
        [StringLength(40)]
        public string FirstName { get; set; }
        
        [Required]
        [DataType(DataType.Text)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(1000, MinimumLength = 8)]
        public string Password { get; set; }
        [Required]
        [System.Web.Mvc.Compare("Password")]
        [DataType(DataType.Password)]
        public string PasswordConfirmation { get; set; }
