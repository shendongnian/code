    foreach (DataGridViewRow row in yourDataGridView.Rows)
    {
    	if(ping(row.Cells[0]))
		{
			row.Cells[1].Value == Properties.Resources.online;
		}
		else
		{
			row.Cells[1].Value == Properties.Resources.offline;
		}
    }
