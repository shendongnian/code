    var sortKey = "name"; // use your sortKey
    Expression<Func<User, string>> sortExpression;
    switch (sortKey)
    {
        case "email":
            sortExpression = x => x.Email;
            break;
        case "name":
            sortExpression = x => x.Name;
            break;
        default:
            sortExpression = x => x.Name;
            break;
    }
    using (var ctx = new MyEntities())
    {
        result = ctx.Users
           .MyOrderByType(sortType, sortExpression)
           .ToList();                
    }
    // defined below
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
