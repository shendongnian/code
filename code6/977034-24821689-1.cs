    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {            
        modelBuilder.Entity<ApplicationUser>().HasRequired(c => c.Contact)
            .WithMany()
            .HasForeignKey(c => c.ContactId);
        base.OnModelCreating(modelBuilder);
    }
