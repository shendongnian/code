    public class ApplicationUser : IdentityUser<int>
    {
        
    }
    
    public class ApplicationRole : IdentityRole<int>
    {
    
    }
    
    public class MyDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        
    }
