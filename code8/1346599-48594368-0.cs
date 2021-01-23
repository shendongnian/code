    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
    {
        private Dictionary<string, dynamic> _repositories;
        private DbContext _context;
        public UnitOfWork(TContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IRepository<TEntity> Repository<TEntity>() where TEntity : class, IEntity, new()
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, dynamic>();
            }
            var type = typeof(TEntity).Name;
            if (_repositories.ContainsKey(type))
            {
                return (IRepository<TEntity>)_repositories[type];
            }
            _repositories.Add(type, Activator.CreateInstance(typeof(RepositoryEntityFramework<TEntity>), _context));
            return _repositories[type];
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public void BeginTransaction(System.Data.IsolationLevel isolationLevel = System.Data.IsolationLevel.ReadCommitted)
        {
            _context.Database.BeginTransaction();
        }
        public bool Commit()
        {
            _context.Database.CommitTransaction();
            return true;
        }
        public void Rollback()
        {
            _context.Database.RollbackTransaction();
        }
        /// <inheritdoc />
        /// <summary>
        /// Disposes the current object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
