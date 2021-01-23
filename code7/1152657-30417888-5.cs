    public class User
    {
        [Required]
        [Remote("IsUserNameValid", "Users", "Admin", 
           AdditionalFields = "UserID", ErrorMessage = "Username already exists.")]
        public string UserName { get; set; }
    
        [Required]
        public string UserPassword { get; set; }
        // other properties...
    }
