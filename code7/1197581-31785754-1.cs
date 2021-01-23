    public class User
    {
        public string Name {get;set;}
    }
    public class MyEntities : DbContext 
	{ 
		public DbSet<User> Users { get; set; }
	}
