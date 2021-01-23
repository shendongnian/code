     public class GenericTable
    {
        
        private string tableName = "";
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }
        
        private ObservableCollection<DataGridColumn> columnCollection;
        public ObservableCollection<DataGridColumn> ColumnCollection
        {
            get { return columnCollection; }
            private set { columnCollection = value; }
        }
    
        private ObservableCollection<GenericRow> genericRowCollection;
        public ObservableCollection<GenericRow> GenericRowCollection
        {
            get { return genericRowCollection; }
            set { genericRowCollection = value; }
        }
    
    
    
    
        public GenericTable(string tableName)
        {
            this.TableName = tableName;
            ColumnCollection = new ObservableCollection<DataGridColumn>();
            GenericRowCollection = new ObservableCollection<GenericRow>(); 
        }
    
        /// <summary>
        /// ColumnName is also binding property name
        /// </summary>
        /// <param name="columnName"></param>
        public void AddColumn(string columnName)
        {
            DataGridTextColumn column = new DataGridTextColumn();
            column.Header = columnName;
            column.Binding = new Binding(columnName);
            ColumnCollection.Add(column);
        }
    
       
    
        public override string ToString()
        {
            return TableName; 
        }
    
    
    }
