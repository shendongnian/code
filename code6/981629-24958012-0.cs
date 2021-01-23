    public interface IUnitOfWork {}
    
    // both named A and B
    public class UnitOfWorkA : IUnitOfWork {}
    
    public class UnitOfWorkB : IUnitOfWork {}
    
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
    	protected DbSet<TEntity> DbSet;
    
        private readonly DbContext dbContext;
    
        public GenericRepository(IUnitOfWork unitOfWork)
        {
            dbContext = (DbContext)unitOfWork;
            DbSet = dbContext.Set<TEntity>();
        }
         // other IGenericRepository methods
    }
    
    public class GenericRepositoryForA<TEntity> : GenericRepository<TEntity>
    {
    	public GenericRepositoryForA([Named("A")]IUnitOfWork unitOfWork) 
    		: base(unitOfWork)
    	{
    
    	}
    }
    
    public class GenericRepositoryForB<TEntity> : GenericRepository<TEntity>
    {
    	public GenericRepositoryForB([Named("B")]IUnitOfWork unitOfWork) 
    		: base(unitOfWork)
    	{
    
    	}
    }
