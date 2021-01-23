    public interface IRepository<TEntity,TKey> where TEntity : class
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                string includeProperties = "");
        TEntity GetById(TKey id);
        void Insert(TEntity entityToAdd);
        void Update(TEntity entityToUpdate);
        void Delete(TKey id);
    }
    public class GenericRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
       //Set the variables here
        internal UsersContext context;
        internal DbSet<TEntity> dbSet;
       //Prepare the enviroment here
        public GenericRepository(UsersContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
       /// <summary>
       /// To get all the records
       /// </summary>
       /// <param name="filter">Get the filter expression</param>
       /// <param name="orderBy">Get the order by parameters</param>
       /// <param name="includeProperties">Get the include properties</param>
       /// <returns>return the list of records</returns>
        public IEnumerable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, 
                                                                IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return query.ToList();
        }
       /// <summary>
       /// Get the entity by id
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public TEntity GetById(TKey id)
        {
            return dbSet.Find(id);
        }
       /// <summary>
       /// Insert the record
       /// </summary>
       /// <param name="entityToAdd">Get the entity to insert</param>
        public void Insert(TEntity entityToAdd)
        {
            dbSet.Add(entityToAdd);
        }
        /// <summary>
        /// Update the record
        /// </summary>
        /// <param name="entityToUpdate">Get the entity to update</param>
        public void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
        /// <summary>
        /// Delete the entity
        /// </summary>
        /// <param name="id">Get the id to delete</param>
        public void Delete(TKey id)
        {
            TEntity entityToDelete = dbSet.Find(id);           
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            
            dbSet.Remove(entityToDelete);
        }
    }
