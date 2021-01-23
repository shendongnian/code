    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity FindById(object id);
        TEntity FindByName(object name);
    }
    public interface IUnitOfWork
    {
        void Dispose();
        void Save();
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
    } 
