    public interface ITableMapper
    {
        // Use Sytem.Type arguments where appropriate and
        // the object type instead of generic types
        ...
    }
    public class TableMapper<TSource> : ITableMapper
    {
        ...
    }
