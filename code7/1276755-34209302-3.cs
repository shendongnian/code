    public class UserContext : DbContext
    {
        public UserContext(string connection_string)
            :base(connection_string)
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<DrcAuthentication.DrcMaster> DrcMasters { get; set; }
        public DbSet<DrcAuthentication.AuthenticatedUser> Users { get; set; }
        public DbSet<DrcAuthentication.UserRole> UserRoles { get; set; }
        //public IDbSet<SuperSecured> SuperSecured { get; set; }
    
    }
