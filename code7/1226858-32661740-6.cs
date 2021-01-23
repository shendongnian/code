    public class UserProfile
    {
        public int UserProfileId { get; set; } // PK
        // some properties omitted
        // we don't have Login property here
    }
    
    public class Login
    {
        //login pk must be userprofile FK
        //so it ensures the 1:1 relationship
        public int UserProfileId { get; set; } //PK
        public string UserName { get; set; }
    
        public UserProfile Profile { get; set; }// UserProfile's FK
    }
