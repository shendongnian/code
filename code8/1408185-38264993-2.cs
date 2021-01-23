	char charac = 'A';
	for (int k = 1; k <= 3; k++)
	{
		for (int m = 1; m <= 4; m++)
		{
			dt.Columns.Add("Name_" + charac + m);
			dt.Columns.Add("Class_" + charac + m);
			dt.Columns.Add("Score_" + charac + m);
		}
		charac++;
	}
