    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {    
        modelBuilder.Entity<AspNetUser>()
            .HasMany(x => x.Roles)
            .WithMany(x => x.AspNetUsers)
        .Map(x =>
        {
            x.ToTable("AspNetUserRoles"); // third table is named Cookbooks
            x.MapLeftKey("AspNetUserId");
            x.MapRightKey("RoleId");
        });
    }
