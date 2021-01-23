    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
                    .HasMany(d => d.Teams)
                    .WithMany(f => f.Users)
                    .Map(w => w.ToTable("UserTeam")
                               .MapLeftKey("UserId")
                               .MapRightKey("TeamId"));
    }
