    public interface IEntity<T> {
        T Id { get; set; }
    }
    
    public abstract class BaseEntity<T>: IEntity<T> { 
        public virtual T Id { get; set; }
    }
    
    public abstract class Entity<T> : BaseEntity<T> {
        // No need to implement the Id property, we already have it inherited
    }
