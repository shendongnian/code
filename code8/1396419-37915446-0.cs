    public interface ITable<out T>
    {
        //some stuff
    }
    
    public class ChildType : ParentType
    {
        //some stuff
    }
    
    public ITable<ParentType> GetTableFromContext() {
        ITable<ChildType> result = null;
        return result;
    }
