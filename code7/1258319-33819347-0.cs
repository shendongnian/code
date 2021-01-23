	public partial class MyDbContext: DbContext
    {
        public MyDbContext() : base("name=MyDbContext") { }
        public static MyDbContext Create()
        {
            return new MyDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            // Needed to ensure subclasses share the same table
            var user = modelBuilder.Entity<IdentityUser>()
                .ToTable("Users");
            user.HasMany(u => u.Roles).WithRequired().HasForeignKey(ur => ur.UserId);
            user.HasMany(u => u.Claims).WithRequired().HasForeignKey(uc => uc.UserId);
            user.HasMany(u => u.Logins).WithRequired().HasForeignKey(ul => ul.UserId);
            user.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UserNameIndex") { IsUnique = false })); // Unique False because there might have same UserName between EntitySet
            // CONSIDER: u.Email is Required if set on options?
            user.Property(u => u.Email).HasMaxLength(256);
            modelBuilder.Entity<IdentityUserRole>()
                .HasKey(r => new { r.UserId, r.RoleId })
                .ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId })
                .ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("UserClaims");
            var role = modelBuilder.Entity<IdentityRole>()
                .ToTable("Roles");
            role.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("RoleNameIndex") { IsUnique = false }));
            role.HasMany(r => r.Users).WithRequired().HasForeignKey(ur => ur.RoleId);
            modelBuilder.Entity<SystemOwnerApplicationUser>().ToTable("SystemOwnerApplicationUsers");
            modelBuilder.Entity<DistributorApplicationUser>().ToTable("DistributorApplicationUsers");
            modelBuilder.Entity<AgentApplicationUser>().ToTable("AgentApplicationUsers");
            modelBuilder.Entity<SubagentApplicationUser>().ToTable("SubagentApplicationUsers");
        }
        public virtual DbSet<SystemOwnerApplicationUser> SystemOwnerApplicationUsers { get; set; }
        public virtual DbSet<DistributorApplicationUser> DistributorApplicationUsers { get; set; }
        public virtual DbSet<AgentApplicationUser> AgentApplicationUsers { get; set; }
        public virtual DbSet<SubagentApplicationUser> SubagentApplicationUsers { get; set; }
    }
