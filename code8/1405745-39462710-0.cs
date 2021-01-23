    public class ApplicationUser : IdentityUser<Guid> { }
    
    public class ApplicationRole : IdentityRole<Guid> { }
    
    public class ApplicationUserStore : UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, Guid>
    {
        public ApplicationUserStore(ApplicationDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }
    }
