      public class Users
    {
        
        public int UserId { get; set; }
        public string Emails { get; set; }
        public UserLogins UserLogins { get; set; }
    }
    public class UserLogins
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Users> Users { get; set; }
    }
    public class UsersMap : EntityTypeConfiguration<Users>
    {
        public UsersMap()
        {
            this.HasKey(x => x.UserId);
            this.Property(x => x.Emails).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute() { IsUnique = true }));
            this.HasRequired(x => x.UserLogins).
                WithMany(x => x.Users).HasForeignKey(x => x.Emails);
        }
    }
    public class UserLoginMap : EntityTypeConfiguration<UserLogins>
    {
        public UserLoginMap()
        {
            this.HasKey(x => x.Email);
        }
    }
    public class TotalDbContext : DbContext
    {
        public TotalDbContext()
            : base("Name=total")
        { 
        
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserLogins> UserLogins { get; set; }
        protected override void OnModelCreating(DbModelBuilder model)
        {
            model.Configurations.Add(new UsersMap());
            model.Configurations.Add(new UserLoginMap());
        }
    
    }
