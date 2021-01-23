	foreach (DataGridViewRow row in yourDataGridView.Rows)
	{
		if (ping(row.Cells[0]))
		{
			row.Cells[1].Value = Properties.Resources.online;
		}
		else
		{
			row.Cells[1].Value = Properties.Resources.offline;
		}
		if (checkProcess(row.Cells[2]))
		{
			row.Cells[3].Value = Properties.Resources.online;
		}
		else
		{
			row.Cells[3].Value = Properties.Resources.offline;
		}
	}
