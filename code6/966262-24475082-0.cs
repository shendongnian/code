    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
 
        modelBuilder.Entity<ApplicationUser>()
            .Property(p => p.Id)
            .HasColumnName("UserId");
    }
