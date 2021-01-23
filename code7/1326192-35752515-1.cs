    public interface IDataSource<out T>
    {
        ...
    }
    
    public abstract class DataSource<T> : IDataSource<T>
    {
        ...
    }
    
    public class XlsxDataSource : DataSource<Row>
    {
        // Overriden methods and constructor
    }
