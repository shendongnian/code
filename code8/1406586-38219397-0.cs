    public enum ObjectState
    {
        Unchanged = 0,
        Added = 1,
        Modified = 2,
        Deleted = 3
    }
    public interface IObjectWithState
    {
        ObjectState ClientState { get; set; }
    }
    public abstract class BaseEntity : IBaseEntity, IPrimaryKey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public bool IsNew => Id <= 0;
        [NotMapped]
        public ObjectState ClientState { get; set; } = ObjectState.Unchanged;
    }
