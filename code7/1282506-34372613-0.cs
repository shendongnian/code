    protected override void OnModelCreating(ModelBuilder builder) 
    {
        base.OnModelCreating(builder);
    
        builder.Entity<Country>().ToTable("Countries");
        builder.Entity<Country>().HasKey(x => x.Code);
        builder.Entity<Country>().Property(x => x.Code).IsRequired().HasMaximumLength(2).ValueGeneratedNever();
        builder.Entity<Country>().Property(x => x.Name).IsRequired().HasMaxLength(80);        
    
        builder.Entity<User>().ToTable("User");
        builder.Entity<User>().HasKey(x => x.CountryCode);
        builder.Entity<User>().Property(x => x.CountryCode).IsRequired().HasMaximumLength(2).ValueGeneratedNever();
        builder.Entity<User>()
            .HasOne(x => x.Country)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.CountryCode);
    
    }
