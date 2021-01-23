	private void AddColumns(DataTable dt, string columnPrefix)
	{
		char charac = 'A';
		for (int k = 1; k <= 3; k++)
		{
			for (int m = 1; m <= 4; m++)
			{
				dt.Columns.Add(columnPrefix + charac + m);
			}
			charac++;
		}
	}
	
