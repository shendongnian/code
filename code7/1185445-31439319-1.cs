    DataTable newDataTable = yourDataTable.Clone();
    newDataTable.Columns["BoolTypeColumnName"].DataType = typeof(bool);
    foreach (DataRow row in yourDataTable.Rows) 
    {
        newDataTable.ImportRow(row);
    }
    this.YourDataGridView.DataSource = newDataTable;
   
