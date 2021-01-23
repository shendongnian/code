        public class Provider<TEntity> where TEntity : class
        {
            protected IObjectSet<TEntity> _dbSet;
            protected ObjectContext _context;
    
            public Provider(ObjectContext context)
            {
                _context = context;
                _dbSet = context.CreateObjectSet<TEntity>();
            }
    
            public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> whereClause= null)
            {
                IQueryable<TEntity> dbSet = _dbSet;
    
                if (whereClause!= null) 
                    dbSet = dbSet.AsExpandable().Where(whereClause);
    
                return dbSet;
            }
            public virtual IEnumerable<TEntity> FindReadOnly(Expression<Func<TEntity, bool>> whereClause= null)
            {
                IQueryable<TEntity> dbSet = _dbSet.AsNoTracking();
    
                if (whereClause!= null) 
                    dbSet = dbSet.AsExpandable().Where(whereClause);
    
                return dbSet;
            }
        }
      
