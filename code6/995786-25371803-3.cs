    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity {
        protected readonly MyDbContext _context;
        protected readonly DbSet<T> _dbSet;
    
        public GenericRepository(MyDbContext context) {
            _context = context;
            _dbSet = context.Set<T>();
        }
    
        //Would like to limit object to be of type BaseEntity or ICollection<BaseEntity>
        public IQueryable<TEntity> Get(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = _dbSet.AsQueryable();
    //Something like that may help? wont solve the issue of intelisense knowing what is allowed and what is not allowed. 
    
            includeProperties = includeProperties.Where(p=>p.Type.DeclaringType.GetCustomAttributes(typeof(NavigationProperty),true).Any());
    
            foreach (var include in includeProperties){
                query = query.Include(include);
            }
    
            return query;
        }
    }
