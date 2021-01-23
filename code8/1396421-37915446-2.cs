    public interface ITable<out T>
    {}
    public class Table<T> : ITable<T>
    {}    
    
    public ITable<ParentType> GetTableFromContext() {
        return new Table<ChildType>();
    }
