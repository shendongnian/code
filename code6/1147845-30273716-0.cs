    public class User 
    {
         public UserProfile Profile { get; set; }
    }
    
    public class UserProfile
    {
         public User OwnerUser { get; set; }
    }
