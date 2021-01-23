    public class ApplicationUser : IdentityUser
    {
         public virtual DateTime LastLoginTime { get; set; }
         public virtual DateTime RegistrationDate { get; set; }
    
        // other properties
    }
