        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage = "*")]
        [CompareCustomAttribute("Password", ClassKey = "Resources", ResourceKey = "PasswordCompare")]
        [NotMapped]
        public string ConfirmPassword { get; set; }
