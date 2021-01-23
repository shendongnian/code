    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    
        // Need to do this because if using as a foreign key it must match the length of the principal key
        builder.Entity<BlogPost>()
            .Property(fp => fp.CreatedBy)
            .HasMaxLength(256);
    
        // A BlogPost has one CreatedByUser (notice we must specify the PrincipalKey to be UserName from the AspNetUsers table otherwise EF would attempt to use the Id (Guid) field by default)
        builder.Entity<BlogPost>()
            .HasOne(bp => bp.CreatedByUser)
            .WithMany()
            .HasForeignKey(bp => bp.CreatedBy)
            .HasPrincipalKey(u => u.UserName)
            .IsRequired();
    }
