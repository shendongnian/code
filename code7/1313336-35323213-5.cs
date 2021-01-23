    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
    
        modelBuilder.Entity<User>()
                    .HasMany(s => s.Roles)
                    .WithMany(c => c.Users)
                    .Map(cs =>
                            {
                                cs.MapLeftKey("UserRefId");
                                cs.MapRightKey("RoleRefId");
                                cs.ToTable("UserRoles");
                            });
    
    } 
