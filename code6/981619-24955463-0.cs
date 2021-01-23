    public class TRZIC {}
    
    public class INIC {}
    
    public interface IUnitOfWork<TEntity> {}
    
    public class TRZICDbContext : DbContext, IUnitOfWork<TRZIC> {}
    
    public class INICDbContext : DbContext, IUnitOfWork<INIC> {}
    
    public interface IGenericRepository<TEntity> {}
    
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        public GenericRepository(IUnitOfWork<TEntity> unitOfWork)
        {
            var dbContext = (DbContext) unitOfWork;
        }
    }
    
    private static void AddBindings(IKernel container)
    {
        container
            .Bind<IUnitOfWork<TRZIC>>()
            .To<TRZICDbContext>();
        container
            .Bind<IUnitOfWork<INIC>>()
            .To<INICDbContext>();
    
        container
            .Bind<IGenericRepository<TRZIC>>()
            .To<GenericRepository<TRZIC>>();
        container
            .Bind<IGenericRepository<INIC>>()
            .To<GenericRepository<INIC>>();
    }
