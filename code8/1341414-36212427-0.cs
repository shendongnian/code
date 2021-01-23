	DataTable dtGrid = gridData.DataSource as DataTable;
	DataTable dtResult = new DataTable();
	Math columnIndex = new Math();
	List<double> avgList = new List<double>();
	foreach (var row in dtGrid.Rows)
	{
		foreach (var column in row.Columns)
		{
			// If this column is a double, you can just use the value 
			instead of doing a ToString and converting it to a double
			avgList.Add(Convert.ToDouble(column.ToString()));	
		}
	}
