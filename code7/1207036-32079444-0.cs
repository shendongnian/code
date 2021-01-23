    if(dataGridView1 != null)
	{
		foreach (DataGridViewRow row in dataGridView1.Rows)
		{                            
			foreach (DataGridViewCell cell in row.Cells)
			{
				if (cell.Value != null && cell.Value.Equals("test"))
				{
					testText = cell.Value;
				}
			}
		}
	}
