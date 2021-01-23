    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //ApplicationUser
            modelBuilder.Entity<ApplicationUser>().HasKey(c => c.Id);
            modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUser", "Usuario");
            //Other entities...
        }
