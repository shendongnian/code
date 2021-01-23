     public class UserManager : UserManager<ApplicationUser>
        {
            public UserManager()
                : base(new UserStore<ApplicationUser>(new ApplicationDbContext()))
            {
            }
        }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext()
                : base("DefaultConnection")
            {
            }
        }
    public class ApplicationUser : IdentityUser
    {
    }
