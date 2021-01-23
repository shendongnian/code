    public interface IReadRepository<T>
    {
        T Get(int id);
    }
    
    public interface IWriteRepository<T> : IReadRepository<T>
    {
        void Add(T entity);
    }
