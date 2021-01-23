    if(dataGridView1 != null)
	{
		foreach (DataGridViewCell cell in dataGridView1.Rows[0].Cells)
		{
			if (cell.Value != null && cell.Value.Equals("test"))
			{
				tst.Text = cell.Value;
			}
		}
	}
