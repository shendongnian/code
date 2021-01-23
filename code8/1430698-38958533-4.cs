    public class One
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public ICollection<Two> Twos { get; set; }
    }
    
    public class Two
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public ICollection<One> Ones { get; set; }
    }
    
    public class MyDbContext : DbContext
    {
    	public DbSet<One> Ones { get; set; }
    	public DbSet<Two> Twos { get; set; }
    }
