    public class HRCTX : IDisposable
    {
        private readonly HRMainDataCTX _context;
        private Dictionary<Type, object> Repositories { get; set; }
        public HRCTX()
        {
            _context = new HRMainDataCTX();
            this.Repositories = new Dictionary<Type, object>();
        }
		
		//Get and add a repository to the dictionary if ot does not exist
		public IRepository<TEntity> GetNonGenericRepository<TEntity, TRepository>() where TEntity : class
        {
            if (this.Repositories.Keys.Contains(typeof(TRepository)))
            {
                return this.Repositories[typeof(TRepository)] as IRepository<TEntity>;
            }
            var repoType = typeof(TRepository);
            var constructorInfo = repoType.GetConstructor(new Type[] { typeof(DbContext)});
            IRepository<TEntity> repository = (IRepository<TEntity>) constructorInfo.Invoke(new object[] { this._context});
            this.Repositories.Add(typeof(TRepository), repository);
            return repository;
        }
     public IRepository<TEntity> GetGenericRepository<TEntity>() where TEntity :     class
        {
            if (this.Repositories.Keys.Contains(typeof(TEntity)))
            {
                return this.Repositories[typeof(TEntity)] as IRepository<TEntity>;
            }
            
            IRepository<TEntity> repository = new Repository<TEntity>(this._context);
            this.Repositories.Add(typeof(TEntity), repository);
            return repository;
        }
    }
