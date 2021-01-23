	foreach (DataGridViewRow row in yourDataGridView.Rows)
	{
		if (ping(row.Cells[1]))
		{
			row.Cells[2].Value = Properties.Resources.online;
		}
		else
		{
			row.Cells[2].Value = Properties.Resources.offline;
		}
		if (checkProcess(row.Cells[3]))
		{
			row.Cells[4].Value = Properties.Resources.online;
		}
		else
		{
			row.Cells[4].Value = Properties.Resources.offline;
		}
	}
