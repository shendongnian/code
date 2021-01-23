	DataTable result = new DataTable();
	// add column for string value of key:
	result.Columns.Add("__key", typeof(string));
	// add columns from table1:
	foreach (var col in table1.Columns.OfType<DataColumn>())
		result.Columns.Add("T1_" + col.ColumnName, col.DataType);
	// add columns from table2:
	foreach (var col in table2.Columns.OfType<DataColumn>())
		result.Columns.Add("T2_" + col.ColumnName, col.DataType);
