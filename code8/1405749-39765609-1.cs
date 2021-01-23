        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        //public new DbSet<ApplicationUserClaim> UserClaims { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
      services.AddIdentity<ApplicationUser, ApplicationRole>()
                    .AddEntityFrameworkStores<AppDbContext, Guid>()
                    .AddDefaultTokenProviders()
                    .AddUserStore<UserStore<ApplicationUser, ApplicationRole, AppDbContext, Guid>>()
                    .AddRoleStore<RoleStore<ApplicationRole, AppDbContext, Guid>>()
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            //this.Id = Guid.NewGuid();
        }
        public ApplicationUser(string userName) : this() { this.UserName = userName; }
        public Guid ClientId { get; set; }
        //public new ICollection<ApplicationUserClaim> Claims { get; set; }
    }
    //public class ApplicationRole : IdentityRole<Guid, ApplicationUserRole, ApplicationRoleClaim>
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole()
        {
            //this.Id = Guid.NewGuid();
        }
        public ApplicationRole(string name) : this() { this.Name = name; }
    }
    public class ApplicationRoleClaim : IdentityRoleClaim<Guid> { }
    //[NotMapped]
    public class ApplicationUserClaim : IdentityUserClaim<Guid> { }
    public class ApplicationUserLogin : IdentityUserLogin<Guid> { }
    public class ApplicationUserRole : IdentityUserRole<Guid> { }
    public class ApplicationUserToken : IdentityUserToken<Guid> { }
