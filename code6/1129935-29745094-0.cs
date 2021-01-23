    public interface IRepository<T>
    {
        void Add(T model);
    }
    
    public class Repository<T> : IRepository<T>
    {
        protected List<T> data;
    
        public Repository()
        {
            this.data = new List<T>();
        }
    
        public void Add(T model)
        {
            this.data.Add(model);
        }
    }
