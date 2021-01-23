    public interface IUnitOfWork : IDisposable
        {
            IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;      
            void Save();
        }
----------------------------------------
     public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext, new()
        {
            private readonly DbContext _ctx;
            private readonly Dictionary<Type, object> _repositories;
            private bool _disposed;
    
            public UnitOfWork()
            {
                _ctx = new TContext();
                _repositories = new Dictionary<Type, object>();
                _disposed = false;
            }
    
            public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
            {
                // Checks if the Dictionary Key contains the Model class
                if (_repositories.Keys.Contains(typeof (TEntity)))
                {
                    // Return the repository for that Model class
                    return _repositories[typeof (TEntity)] as IRepository<TEntity>;
                }
    
                // If the repository for that Model class doesn't exist, create it
                var repository = new Repository<TEntity>(_ctx);
    
                // Add it to the dictionary
                _repositories.Add(typeof (TEntity), repository);
    
                return repository;
            }
            
            public void Save()
            {
                // save all changes together
                _ctx.SaveChanges();
            }
    
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
    
            protected virtual void Dispose(bool disposing)
            {
                if (!_disposed)
                {
                    if (disposing)
                    {
                        _ctx.Dispose();
                    }
    
                    _disposed = true;
                }
            }
        }
