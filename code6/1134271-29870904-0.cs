	public class User
	{
		public User()
		{
			this.Id = Guid.NewGuid().ToString();
		}
		
		public string Id { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Post> Posts {get;set;}
	}
	
	public class Post
	{
		public Post()
		{
			this.Id = Guid.NewGuid().ToString();
		}
	
		public string Id { get; set; }	
		public string UserId { get; set; }
		public virtual User Author {get;set;}
		public string Title { get; set; }
		public string Body { get; set; }
	} 
	
	public class UserConfiguration : EntityTypeConfiguration<User>
	{
		public UserConfiguration()
		{
			this.ToTable("Users");
			this.HasKey(user => user.Id);
			this.Property(user => user.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
			this.Property(user => user.Name).IsRequired();
			
			this.HasMany(user => user.Posts).WithRequired(post => post.Author).HasForeignKey(post => post.UserId);
		}
	}
	public class PostConfiguration : EntityTypeConfiguration<Post>
	{
		public PostConfiguration()
		{
			this.ToTable("Posts");
			this.HasKey(post => post.Id);
			this.Property(post => post.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
			this.Property(post => post.UserId).IsRequired();
			this.Property(post => post.Title).IsRequired();
			this.Property(post => post.Body).IsRequired();
			
			this.HasRequired(post => post.Author).WithMany(user => user.Posts).HasForeignKey(post => post.UserId);
		}
	}
	
	public class ExampleContext : DbContext
	{
		public ExampleContext() : base("DefaultConnection") 
					// Ensure you have a connection string in App.config / Web.Config 
					// named DefaultConnection with a connection string
		{
		}
		
		public DbSet<Post> Posts { get; set; }
		public DbSet<User> Users { get; set; }
		
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new PostConfiguration());
			modelBuilder.Configurations.Add(new UserConfiguration());
		}
	}
