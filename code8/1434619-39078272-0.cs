    public class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
    {
        public BaseRepository(CustomDBContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context", "The given parameter cannot be null.");
            }
            this.Context = context;
        }
        protected CustomDBContext Context
        {
            get;
            private set;
        }
        public T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }
        public void AddOrUpdate(T entity)
        {
            //Context.Set<T>().Attach(entity);
            Context.Entry(entity).State = ((EntityBase)entity).Id == 0 ?
                    System.Data.Entity.EntityState.Added :
                    System.Data.Entity.EntityState.Modified;
        }
       .....
    }
