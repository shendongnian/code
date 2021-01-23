    public class MyRepository<TEntity> : GenericRepository<TEntity> where TEntity : class
    {
    	public MyRepository(object context)
    		:base(context)
    	{
    		
    	}
    }
