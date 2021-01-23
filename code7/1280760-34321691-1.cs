	foreach (DataGridViewRow row in yourDataGridView.Rows)
	{
		for (int i = 0; i < row.Cells.Count; i++)
		{
			if(ping(row.Cells[i]))
			{
				//update row.Cells[i+1];
				i++;
			}
		}
	}
