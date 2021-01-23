        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        protected ApplicationDbContext() { }
        public new DbSet<TRoleClaim> RoleClaims { get; set; }
        public new DbSet<TRole> Roles { get; set; }
        public new DbSet<TUserClaim> UserClaims { get; set; }
        public new DbSet<TUserLogin> UserLogins { get; set; }
        public new DbSet<TUserRole> UserRoles { get; set; }
        public new DbSet<TUser> Users { get; set; }
        public new DbSet<TUserToken> UserTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
