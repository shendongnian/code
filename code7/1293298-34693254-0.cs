    private void dtChangeZeroToNull (DataTable dataTable){
		List<string> dcNames = dataTable.Columns
                                .Cast<DataColumn>()
                                .Select(x => x.ColumnName)
                                .ToList(); //This querying of the Column Names, you could do with LINQ
		foreach (DataRow row in dataTable.Rows) //This is the part where you update the cell one by one
			foreach (string columnName in dcNames)
				row[columnName] = (int)row[columnName] == 0 ? DBNull.Value : row[columnName];				
    }
