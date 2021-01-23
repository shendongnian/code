    public Class User
    {
        [Required]
        [Remote("IsUsernameValid", "ControllerName", 
           AdditionalFields = "UserID", ErrorMessage = "Username already exists.")]
        public string UserName { get; set; }
    
        [Required]
        public string UserPassword { get; set; }
    }
