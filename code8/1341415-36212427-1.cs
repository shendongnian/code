	DataTable dtGrid = gridData.DataSource as DataTable;
	DataTable dtResult = new DataTable();
	Math columnIndex = new Math();
	List<double> avgList = new List<double>();
	for (int k = 1; k < dtGrid.Rows.Count; k++)
	{
		for (int i = 0; i < dtGrid.Columns.Count; i++)
		{
			// ??
			avgList.Add(Convert.ToDouble(dtGrid.Rows[k].Columns[i].ToString()));
		}
	}
