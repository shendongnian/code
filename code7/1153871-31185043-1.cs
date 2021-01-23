                protected override void OnModelCreating(DbModelBuilder modelBuilder)
                        {
                            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                            base.OnModelCreating(modelBuilder);
                            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");
    //modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id).ToTable("AspNetRoles");
    //modelBuilder.Entity<IdentityUser>().ToTable("AspNetUsers");
    //modelBuilder.Entity<IdentityUserLogin>().HasKey(l => new { l.UserId, l.LoginProvider, l.ProviderKey }).ToTable("AspNetUserLogins");
    //modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId }).ToTable("AspNetUserRoles");
    //modelBuilder.Entity<IdentityUserClaim>().ToTable("AspNetUserClaims");
    }
