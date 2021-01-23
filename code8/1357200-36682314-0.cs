    public interface IEntity
    {
    	bool? Archived { get; set; }
    	bool IsNew { get; }
    }
    
    public interface IEntity<T> : IEntity
    {
    	T Id { get; set; }
    }
    
    public abstract class Entity<T> : IEntity<T>
    {
    	public abstract T Id { get; set; }
    
    	[Column("IsArchived")]
    	public bool? Archived { get; set; }
    
    	public virtual bool IsNew { get { return EqualityComparer<T>.Default.Equals(Id, default(T)); } }
    }
