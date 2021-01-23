    public class Table
    {
        public enum ColumnNames
        {
            ID,
            TableName,
            Active,
            Date
        }
        public List<TableParameter> Parameters;
        public Table()
        {
            Parameters = new List<TableParameter>();
        }
    }
