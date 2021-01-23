	foreach (DataGridViewRow row in yourDataGridView.Rows)
	{
		for (int i = 0; i < row.Cells.Count; i++)
		{
			if(ping(i))
			{
				//update row.Cells[i+1];
				i++;
			}
		}
	}
