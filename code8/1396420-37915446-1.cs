    public interface ITable<out T>
    {
        //some stuff
    }
    public class Table<T> : ITable<T>
    {
        //some stuff 
    }    
    
    public ITable<ParentType> GetTableFromContext() {
        return new Table<ChildType>();
    }
