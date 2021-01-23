    public class ApplicationUserLogin : IdentityUserLogin<int>
    {
    }
    public class ApplicationUserRole : IdentityUserRole<int>
    {
        
    }
    public class ApplicationUserClaim : IdentityUserClaim<int>
    {
    }
    public class ApplicationUser : IdentityUser<int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        
    }
