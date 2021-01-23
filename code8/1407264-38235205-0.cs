    public interface ITableMapper
    {
        // Use Sytem.Type arguments where appropriate instead of generic type parameters
        ...
    }
    public class TableMapper<TSource> : ITableMapper
    {
        ...
    }
