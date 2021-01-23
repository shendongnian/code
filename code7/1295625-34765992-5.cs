    public class FooTableUser
    {
        public FooTableUser([TableId(Tables.FooTable)] ITableWrapper tableWrapper)
        {
            TableWrapper = tableWrapper;
        }
        public ITableWrapper TableWrapper { get; private set; }
    }
    public class BarTableUser
    {
        public BarTableUser([TableId(Tables.BarTable)] ITableWrapper tableWrapper)
        {
            TableWrapper = tableWrapper;
        }
        public ITableWrapper TableWrapper { get; private set; }
    }
