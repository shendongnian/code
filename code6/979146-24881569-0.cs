    public abstract class Entity { }
    public abstract class Entity<T> : Entity, IEntity<T>       
    {
        public T Id { get; set; }
    }
    public abstract class Repository<T> : IRepository<T>
       where T : Entity
    {
    }
