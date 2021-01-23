       protected override void OnModelCreating(DbModelBuilder builder)
    {
        builder.Entity<User>()
             .Property(u => u.PhoneNumber)
             .HasColumnName("NewName");
    }
