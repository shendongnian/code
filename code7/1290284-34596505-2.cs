    public interface IReadonlyRepository<out T> where T : class, IEntity
    {
        IEnumerable<T> Read();    
    }
    public interface IRepository<T>: IReadonlyRepository<T> where T : class, IEntity
    {
        bool Update(IEnumerable<T> entities);
        bool Delete(IEnumerable<T> entities);
        bool Create(IEnumerable<T> entities);
    }
