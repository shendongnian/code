    public class ExampleOfGenericRepository<TEntity> : Repository<TEntity>
		where TEntity : class
	{
    	public ExampleOfGenericRepository(DbContext context)
    		: base(context)
    	{
    	}
    
    	public TEntity GetById(int id)
    	{
    		return Mapper.Map<TEntity>(Get(id));
    	}
    }
