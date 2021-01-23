    public class Context : DbContext
    {
    	public virtual DbSet<what> what { get; set; }
    	public virtual DbSet<why> why { get; set; }
    	public Context() : base("name=SqlConnection")
    	{
    	}
    }
