    public class P
    {
    	public int Id { get; set; }
    	public string Info { get; set; }
    }
    
    public class P1 : P
    {
    	public P2 P2 { get; set; }
    	public P3 P3 { get; set; }
    }
    
    public class P2 : P
    {
    	public P4 P4 { get; set; }
    	public ICollection<P1> P1s { get; set; }
    }
    
    public class P3 : P
    {
    	public ICollection<P1> P1s { get; set; }
    }
    
    public class P4 : P
    {
    	public ICollection<P2> P2s { get; set; }
    }
    
    public class MyDbContext : DbContext
    {
    	public DbSet<P1> P1s { get; set; }
    	public DbSet<P2> P2s { get; set; }
    	public DbSet<P3> P3s { get; set; }
    	public DbSet<P4> P4s { get; set; }
    
    	// ...
    
    	protected override void OnModelCreating(ModelBuilder modelBuilder)
    	{
    		modelBuilder.Entity<P1>().HasOne(e => e.P2).WithMany(e => e.P1s).HasForeignKey("P2Id").IsRequired();
    		modelBuilder.Entity<P1>().HasOne(e => e.P3).WithMany(e => e.P1s).HasForeignKey("P3Id").IsRequired();
    		modelBuilder.Entity<P2>().HasOne(e => e.P4).WithMany(e => e.P2s).HasForeignKey("P4Id").IsRequired();
    		base.OnModelCreating(modelBuilder);
    	}
    }
