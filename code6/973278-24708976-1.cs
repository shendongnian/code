        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<IdentityUserLogin>().HasKey(t => t.UserId);
            modelBuilder.Entity<IdentityUserRole>().HasKey(t => t.UserId);
        }
