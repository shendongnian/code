	try
	{
		foreach (DataGridViewRow row in dgSubjectGridView.Rows)
		{
			Boolean checkstate = Convert.ToBoolean(row.Cells[0].Value);
			if (checkstate == true)
			{
				dgSubjectGridView2.Rows.Add(false, row.Cells[1].Value.ToString());
				dgSubjectGridView.Rows.RemoveAt(row.Index);
			}
		}
	}
