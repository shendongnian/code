    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
    	// ... code ...
    	
    	public virtual void BulkInsert(List<TEntity> list)
        {
            _context.BulkInsert(list);
        }
    }
