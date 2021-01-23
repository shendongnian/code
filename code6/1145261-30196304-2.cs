    void Main()
    {
    	using (AppContext context = new AppContext())
    	{
    		context.Users.AddOrUpdate(...);
    	}
    }
    
    public class AppContext : DbContext
    {
    	public DbSet<User> Users { get; set; }
    	
    	
    }
    
    public class User 
    {
    	public string UserId { get; set; }
    	public string Name { get; set; }
    }
