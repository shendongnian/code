    public class TableSchema
    {
        public string Database {  get; internal set; }
        public string TableName { get; internal set; }
        public List<ColumnSchema> Columns { get; internal set; }
    }
