    public class Repository<T> where T : BaseEntity
    {
        private readonly FlowContext context;
        private IDbSet<T> entities;
        string errorMessage = string.Empty;
        public Repository(FlowContext context)
        {
            this.context = context;
        }
        public T Get(object id)
        {}
        public void Add(T entity)
        {}
        public void Edit(T entity)
        {}
        public void Delete(T entity)
        {}
        private IDbSet<T> Entities
        {}
    }
