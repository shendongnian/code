    DataTable dataSource = dataGridView.DataSource as DataTable; // if it is a DataTable. If not, please specify in your question
    // let's make a DataTable, which is a copy of your DataSource
    DataTable dataTableFoundIds = new DataTable();
    foreach (DataColumn column in dataSource.Columns)
         dataTableFoundIds.Columns.Add(column.ColumnName, column.DataType);
    // iterate through your routeIds
    foreach (int id in routeIds)
	{
		var row = dataSource.AsEnumerable().FirstOrDefault(item => item["col1"].Equals(id)); // take the first row in your DataSource that matches your routeId
		if (row != null)
		{
			dataTableFoundIds.Rows.Add(row.ItemArray); // if we find something, insert the whole row of our source table
		}
	}
