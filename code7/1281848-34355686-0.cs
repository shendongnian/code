	private void InitializeGrid()
	{
		dgv.Columns.Add("colId", "Id");
		dgv.Columns.Add("colName", "Name");
		for (int c = 1; c <= 100; c++)
		{
			int r = dgv.Rows.Add();
			dgv.Rows[r].SetValues(c, "Person" + c);
		}
		dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
	}
