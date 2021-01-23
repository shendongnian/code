        public interface IUnitOfWork : IDisposable
        {
            /// <summary>
            /// Flushes content of unit of work to the underlying data storage. 
            /// Causes unsaved entities to be written to the data storage.
            /// </summary>
            void Flush();
    
            /// <summary>
            /// Begins the transaction.
            /// </summary>
            ITransaction BeginTransaction();
    
            /// <summary>
            /// Ends transaction.
            /// Note: suggested pattern to manage a transaction is via *using* construct.
            /// You should set input param to null after calling the method.
            /// </summary>
            /// <example>
            /// using ( var tnx = uow.BeginTransaction() ) { /* do some work */ }
            /// </example>
            /// See also <seealso cref="ITransaction"/> interface for more details.
            void EndTransaction(ITransaction transaction);
    
            /// <summary>
            /// Inserts entity to the storage.
            /// </summary>
            void Create<TEntity>(TEntity entity) where TEntity : class;
    
            /// <summary>
            /// Updates entity in the storage.
            /// </summary>
            void Update<TEntity>(TEntity entity) where TEntity : class;
    
            /// <summary>
            /// Updates entity in the storage.
            /// </summary>
            void Merge<TEntity>(TEntity original, TEntity current) where TEntity : class;
    
    
            /// <summary>
            /// Deletes entity in the storage.
            /// </summary>
            void Delete<TEntity>(TEntity entity) where TEntity : class;
    
    
        }
        public interface IRepository<TEntity> where TEntity: class
        {
            void Create(TEntity entity);
            TEntity GetById(object id);
            IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> criteria);
              IEnumerable<TEntity> GetAll();
            void Delete(object id);
            void Delete(TEntity entity);
            void Update(TEntity entity);
            void Merge(TEntity original, TEntity current);
            IUnitOfwork UnitOfWork { get; }
        }
  
 
        public class EntityFrameworkUnitOfWork: DbContext, IUnitOfwork
        {
            public virtual void Flush()
            {
                //The DbContext Save Changes method..
                SaveChanges();
            }    
    
            public virtual void Create<TEntity>(TEntity entity) where TEntity : class
            {
                base.Set<TEntity>().Add(entity);
            }
            
           ..other method implementations...
         }
     public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
        {
            private readonly IUnitOfWork _unitOfWork;
    
            public Repository(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
    
            ...other method implementations...
        }
