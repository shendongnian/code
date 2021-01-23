    public class ApplicationUserStore : 
        UserStore<ApplicationUser, ApplicationRole, int,
        ApplicationUserLogin, ApplicationUserRole, 
        ApplicationUserClaim>, IUserStore<ApplicationUser, int>, 
        IDisposable
    {
        public ApplicationUserStore() : this(new IdentityDbContext())
        {
            base.DisposeContext = true;
        }
  
        public ApplicationUserStore(DbContext context)
            : base(context)
        {
        }
    }
