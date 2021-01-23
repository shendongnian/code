    public class AuthContext : IdentityDbContext<ApplicationUser>
    {
        public AuthContext()
            : base("TestDB",throwIfV1Schema:false)
        {
        }
        public static  AuthContext Create()
        {
            return new AuthContext();
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
