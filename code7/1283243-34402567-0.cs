    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<TUser>(b =>
        {
            b.HasKey(u => u.Id);
            b.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex");
            b.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");
            b.ToTable("AspNetUsers");
            ...
        }
    }
