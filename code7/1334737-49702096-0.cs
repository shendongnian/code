    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<YourView>(entity => {
                entity.HasKey(e => e.ID);
                entity.ToTable("YourView");
                entity.Property(e => e.Name).HasMaxLength(50);
    }        });
