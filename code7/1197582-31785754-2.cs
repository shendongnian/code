    using (var ctx = new MyEntities())
    {
        result = ctx.Users
           .MyOrderByType(sortType, x => x.Name)
           .ToList();                
    }
    public class User
    {
        public string Name {get;set;}
        public string Email {get;set;}
        // other properties
    }
    public class MyEntities : DbContext 
	{ 
		public DbSet<User> Users { get; set; }
	}
