    public interface IRepository<TEntity> where TEntity : IEntity
    {
        T FindById(string Id);
        T Create(T t);
        bool Update(T t);
        bool Delete(T t);
    }
    public interface IEntity
    {
        string Id { get; set; }
    } 
