    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Asp.net Identity
        modelBuilder.Entity<ApplicationUser>().ToTable("User");
        modelBuilder.Entity<ApplicationRole>().ToTable("Role");
        modelBuilder.Entity<ApplicationUserClaim>().ToTable("UserClaims");
        modelBuilder.Entity<ApplicationUserLogin>().ToTable("UserLogins");
        modelBuilder.Entity<ApplicationUserRole>().ToTable("RoleUser");
    }
