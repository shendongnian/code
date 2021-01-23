    public interface IRepositoryFactory
    {
        TRepository Create<TRepository, TEntity>(DbContext context) 
            where TRepository : IRepository<TEntity>
            where TEntity : EntityBase;
    }
