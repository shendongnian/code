    using EntityFramework.DynamicFilters;
    public class MyAppContext : ApplicationDbContext
    {
        public DbSet<A> As { get; set; }
        public DbSet<B> Bs { get; set; }
    	
    	protected override void OnModelCreating(DbModelBuilder modelBuilder)
    	{
    		modelBuilder.Filter("IsDisabled", (Base x) => x.Disabled, false);
    	}
    }
    
    public class A : Base
    {
        public bool LikesMilk { get; set; }
    }
    
    public class B : Base
    {
        public string Name { get; set; }
    }
    
    public class Base
    {
        public int Id { get; set; }
        public bool Disabled { get; set; }
    }
