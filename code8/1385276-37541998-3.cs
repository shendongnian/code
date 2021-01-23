    modelBuilder.Entity<DomainModels.Security.UserRole>()
        .HasKey(x => new { x.UserId, x.RoleId });
    modelBuilder.Entity<DomainModels.Security.UserRole>()
        .HasRequired(x => x.User)
        .WithMany(y => y.UserRoles)
        .HasForeignKey(x => x.UserId)
        .WillCascadeOnDelete();
    modelBuilder.Entity<DomainModels.Security.UserRole>()
        .HasRequired(x => x.Role)
        .WithMany(y => y.UserRoles)
        .HasForeignKey(x => x.RoleId)
        .WillCascadeOnDelete();
