    public class Post
    {
        public int Id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        [StringLength(255)]
        public string message { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema:false)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Change the name of the table to be Users instead of AspNetUsers
            modelBuilder.Entity<IdentityUser>()
                .ToTable("Users");
            modelBuilder.Entity<Post>().HasRequired(p => p.User)
                .WithMany().HasForeignKey(p => p.UserId)
                .WillCascadeOnDelete(false);
        }
    }
