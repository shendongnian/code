    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public class TableIdAttribute : Attribute
    {
        public TableIdAttribute(string tableName)
        {
            TableName = tableName;
        }
        public string TableName { get; private set; }
    }
