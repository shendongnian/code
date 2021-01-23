    [AttributeUsage(AttributeTragets.Class)]
    public class SqlAttribute : Attribute
    {
        public string Select { get; set; }
    }
    [Sql(Select = "SELECT * FROM Products")]
    public class ProductDto : IDataItem
    {
        ....
    }
