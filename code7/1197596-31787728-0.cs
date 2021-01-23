    modelBuilder.Entity<AppUser>().HasMany(au => au.Comments)
    .WithRequired(c => c.AppUser)
    .HasForeignKey(c => c.AppUserID)
    .WillCascadeOnDelete(false);
    modelBuilder.Entity<AppUser>().HasMany(au => au.News)
    .WithRequired(n => n.AppUser)
    .HasForeignKey(n => n.AppUserID)
    .WillCascadeOnDelete(false);
