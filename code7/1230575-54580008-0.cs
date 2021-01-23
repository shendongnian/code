    protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Make sure you add above line
            modelBuilder.Entity<ApplicationUser>().ToTable("aspnetusers");
            modelBuilder.Entity<IdentityRole>().ToTable("aspnetroles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("aspnetuserroles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("aspnetuserclaims");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("aspnetuserlogins");
            //Don't add IdentityUser ToTable aspnetusers
        }
