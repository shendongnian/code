    public interface IRepository<T>
    {
        IQueryable<T> GetQueryable();
        void Save(T item);
    }
    
    public abstract class BaseRepository<T> : IRepository<T>
    {
        public IQueryable<T> GetQueryable() { ... }
        public void Save(T item) { ... }
    }
