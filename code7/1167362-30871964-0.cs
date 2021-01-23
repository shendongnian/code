        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.UserRoles)
                .WithOptional().WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);
        }
