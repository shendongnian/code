    public interface IGMSDbContext 
    {
    	DbSet<Account> Accounts { get; set; }
    
    	int SaveChanges();
    }
    
    public class GMSDbContext: DbContext, IGMSDbContext
    {
    	public DbSet<Account> Accounts { get; set; }
    
    	public GMSDbContext(string connection) : base(connection)
    	{
    	}
    
    	public GMSDbContext() : base("your connection string name")
    	{
    	}
    }
