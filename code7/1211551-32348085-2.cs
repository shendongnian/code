    public class BaseRepository<T> where T : class
    {
        protected BabySitterContext Context;
        private readonly PluralizationService _pluralizer = PluralizationService.CreateService(CultureInfo.GetCultureInfo("en"));
        public BaseRepository(BabySitterContext context)
        {
            this.Context = context;
        }
        public bool Add(T t)
        {
            Context.Set<T>().Add(t);
            Context.SaveChanges();
            return true;
        }
        public bool Update(T t)
        {
            var entityName = GetEntityName<T>();
            object originalItem;
            var key = ((IObjectContextAdapter)Context).ObjectContext.CreateEntityKey(entityName, t);
            if (((IObjectContextAdapter)Context).ObjectContext.TryGetObjectByKey(key, out originalItem))
            {
                ((IObjectContextAdapter)Context).ObjectContext.ApplyCurrentValues(key.EntitySetName, t);
            }
            Context.SaveChanges();
            return true;
        }
        public void Attach(T t)
        {
            if (t == null)
            {
                throw new ArgumentNullException("t");
            }
            Context.Set<T>().Attach(t);
            Context.SaveChanges();
        }
        public void Remove(T t)
        {
            if (t == null)
            {
                throw new ArgumentNullException("t");
            }
            Context.Set<T>().Remove(t);
            Context.SaveChanges();
        }
        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = Context.Set<T>();
            if (filter != null)
            {
                query = query.Where(filter.Expand());
            }
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        private string GetEntityName<TEntity>() where TEntity : class
        {
            return string.Format("{0}.{1}", ((IObjectContextAdapter)Context).ObjectContext.DefaultContainerName, _pluralizer.Pluralize(typeof(TEntity).Name));
        }
        public virtual IEnumerable<T> GetByBusinessKey(T entity)
        {
            return null;
        }
    }    
