    public class MyContext : IdentityDbContext<User, Role, int, UserLogin, UserRole, UserClaim>
    {
    	public MyContext(): base("ConnectionString")
    	{
    
    	}
    }
