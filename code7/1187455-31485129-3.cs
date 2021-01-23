        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
         base.OnModelCreating(modelBuilder);
    
         modelBuilder.Entity<UserRoleAssociation>()
            .HasKey(c => new {c.UserId, c.RoleId, c.AssociationId});
    
         modelBuilder.Entity<UserRoleAssociation>()
            .HasRequired(p => p.User)
            .WithMany(u => u.UserRoleAssociations)
            .HasForeignKey(p => p.UserId);
    
         modelBuilder.Entity<UserRoleAssociation>()
            .HasRequired(p => p.Role)
            .WithMany(r => r.UserRoleAssociations)
            .HasForeignKey(p => p.RoleId);
    
         modelBuilder.Entity<UserRoleAssociation>()
            .HasRequired(p => p.Association)
            .WithMany(a => a.UserRoleAssociations)
            .HasForeignKey(p => p.AssociationId);
        }
