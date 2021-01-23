    public class MyContext : DbContext
    {
    	public virtual DbSet&lt;MyTable&gt; MyTable { get; set; }
    
    	public MyContext(DbConnection connection) :
            base(new DbContextOptionsBuilder().UseNpgsql(connection)
    			.ReplaceService<ISqlGenerationHelper, SqlGenerationHelper>().Options)
    	{
    	}
    }</code></pre>
