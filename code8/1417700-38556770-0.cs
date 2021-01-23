    private class ColumnAndValue
    {
        private string columnName;
        private string columnValue;
    
        public string ColumnName
        {
            get { return columnName; }
            set { columnName = value.Trim(); }
        }
        public string ColumnValue
        {
            get { return columnValue; }
            set { columnValue = value.Trim(); }
        }
        public ColumnAndValue(string colName, string colValue)
        {
           columnName = colName;
           columnValue = colValue;
        }
    }
