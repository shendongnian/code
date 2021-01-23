    public class Column
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class Row 
    {
        public List<Column> Columns { get; set; }
    }
    public class Table
    {
        public List<Row> Rows { get; set; }
    }
