    public class Repository<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
    {
        public Repository(IDataFactory factory)
        {
            Factory= factory;
        }
    
        public IDataFactory Factory{ get; }
    }
