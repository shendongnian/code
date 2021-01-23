    [AttributeUsage(AttributeTargets.All)]
    public class Column : System.Attribute
    {
        public int ColumnIndex { get; set; }
        public Column(int column) 
        {
            ColumnIndex = column;
        }
    } 
