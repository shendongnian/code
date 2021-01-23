    public class User {
       public Guid Id { get; set; }
       public string Name { get; set; }
    
       public virtual ICollection<User> Followers { get; set; }
       public virtual ICollection<User> Following { get; set; }
    }
    
    public class UserContext: DbContext {
        public DbSet<User> Users { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
    
            modelBuiler.Entity<User>()
                .HasMany(u => u.Followers)
                .WithMany(u => u.Following)
                .Map(m => m.MapLeftKey("FollowingUserId")
                    .MapRightKey("FollowerUserId")
                    .ToTable("UserFollowUser")
                );
        }
    }
