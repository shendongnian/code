	foreach (DataGridViewRow row in yourDataGridView.Rows)
	{
		for (int i = 0; i < row.Cells.Count; i++)
		{
			if (ping(row.Cells[i]))
			{
				row.Cells[i + 1].Value = Properties.Resources.online;
				i++;
			}
			else
			{
				row.Cells[i + 1].Value = Properties.Resources.offline;
				i++;
			}
		}
	}
