    public class User
    {
        [Required]
        [Remote("IsUserNameValid", "ControllerName", 
           AdditionalFields = "UserID", ErrorMessage = "Username already exists.")]
        public string UserName { get; set; }
    
        [Required]
        public string UserPassword { get; set; }
        // other properties...
    }
