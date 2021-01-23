    public interface IEntity
    {
        int Id { get; set; }
    }
    public interface IRepository<T> where T : class, IEntity
    {
    }
