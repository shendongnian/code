    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movement>()
                    .Property(i => i.DateMovement)
                    .HasColumnType("Date");
    }
