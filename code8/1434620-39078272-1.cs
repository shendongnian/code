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
        protected ApplicationDbContext Context
        {
            get;
            private set;
        }
        public T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }
       
       .....
    }
