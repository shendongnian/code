    public class UserContext : DbContext
    {
        public static string GetConnectionString()
        {
            System.Data.SqlClient.SqlConnectionStringBuilder csb = new System.Data.SqlClient.SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["UserContext"].ConnectionString.ToString());
            csb.Password = EncryptionUtils.Decrypt(csb.Password);
            string myCs = csb.ToString();
            return myCs;
        }
        public UserContext()
            :base(GetConnectionString())
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
    
    
    
        public DbSet<DrcAuthentication.DrcMaster> DrcMasters { get; set; }
        public DbSet<DrcAuthentication.AuthenticatedUser> Users { get; set; }
        public DbSet<DrcAuthentication.UserRole> UserRoles { get; set; }
        //public IDbSet<SuperSecured> SuperSecured { get; set; }
    
    }
