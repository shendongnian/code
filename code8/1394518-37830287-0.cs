    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
                .HasOptional(f => f.CreatedBy)
                .WithMany()
                .WillCascadeOnDelete(false);
        modelBuilder.Entity<User>()
                .HasOptional(f => f.UpdatedBy)
                .WithMany()
                .WillCascadeOnDelete(false);
        modelBuilder.Entity<User>()
                .HasOptional(f => f.DeletedBy)
                .WithMany()
                .WillCascadeOnDelete(false);
    }
