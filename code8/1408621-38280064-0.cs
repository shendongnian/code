    DataTable runtimeSource = new DataTable();
    DataColumn columnID = new DataColumn("ID", typeof(int));
    DataColumn columnName = new DataColumn("Name", typeof(string));
    DataColumn columnAge = new DataColumn("Age", typeof(string));
    
    runtimeSource.Columns.Add(columnID);
    runtimeSource.Columns.Add(columnName);
    runtimeSource.Columns.Add(columnAge);
    
    gridControl.DataSource = runtimeSource;
    gridControl.PopulateColumns();
