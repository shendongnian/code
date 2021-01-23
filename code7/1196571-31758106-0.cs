    public interface IEntity
    {
        string Id { get; set; } 
    }
    public interface IRepository<T> where T : IEntity
    {
        void Add(T entity);
        void Remove(T entity);
        void Create(T entity);
        T Find(string id);
    }
