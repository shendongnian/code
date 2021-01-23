        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyEntity>()
            .Property(p => p.IsActive).ValueGeneratedNever().HasDefaultValue(null);
        }
