     protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
    
                // Renaming default ASP.NET tables
                modelBuilder.Entity<IdentityUser>().ToTable("Users");
                modelBuilder.Entity<User>().ToTable("Users");
                modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
                modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
                modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
                modelBuilder.Entity<IdentityRole>().ToTable("Roles");
    
              
            
            }
