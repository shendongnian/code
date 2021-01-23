    public class DatabaseResults
    {
        public List<string> ColumnNames { get; set; }
        public List<List<string>> Rows { get; set; }
        public DatabaseResults()
        {
            ColumnNames = new List<string>();
            Rows = new List<List<string>>();
        }
    }
