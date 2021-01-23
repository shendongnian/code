    public interface IPersister<T>
    {
        void Add(T model);
    }
    
    public class Persister<T> : IPersister<T>
    {
        protected List<T> data;
    
        public Persister()
        {
            this.data = new List<T>();
        }
    
        public void Add(T model)
        {
            this.data.Add(model);
        }
    }
