    public abstract class Table
    {}
    public class Table<T> : Table
         where T : IRowDef, new()
    {
         private readonly ObservableCollection<T> _rows = new ...;
    }
