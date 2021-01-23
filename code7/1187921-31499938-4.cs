    public class MyEntities: DbContext
    {
      public DbSet<User> Users { get; set; }
      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
        modelBuilder.Entity<User>()
            .HasMany(x => x.Followers).WithMany(x => x.Following)
            .Map(x => x.ToTable("Followers")
                .MapLeftKey("UserId")
                .MapRightKey("FollowerId"));
      }
    }
