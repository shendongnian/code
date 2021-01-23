    dgvSample.AllowUserToAddRows = false;
    dgvSample.AllowUserToDeleteRows = false;
	for (int i = 0; i <= 10; i++)
	{
		string[] values = new string[] { "1", "Name" };
		dgvSample.Rows.Add(values);
		if (i % 2 == 0)
		{
			DataGridViewRow r = dgvSample.Rows[dgvSample.Rows.Count - 1];
			r.ReadOnly = true;
		}
        else
        {
            r.DefaultCellStyle.BackColor = Color.Yellow;
        }
	}
