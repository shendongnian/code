    modelBuilder.Entity<UsersInRoles>()
        .HasKey(ur=> new { ur.UserId, ur.RoleId}); 
    
    modelBuilder.Entity<UsersInRoles>()
        .HasRequired(ur=> ur.User)
        .WithMany(u => u.Roles)
        .HasForeignKey(ur=> ur.UserId);
    
    modelBuilder.Entity<UsersInRoles>()
        .HasRequired(ur=> ur.Role)
        .WithMany(u => u.Users)
        .HasForeignKey(ur=> ur.RoleId);
