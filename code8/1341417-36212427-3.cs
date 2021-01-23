    for (int k = 1; k < dtGrid.Rows.Count; k++)
	{
		for (int i = 0; i < dtGrid.Columns.Count; i++)
		{
			if (!AvgColumnList.Keys.Contains(i))
				AvgColumnList.Add(i, new List<double>());
				
			AvgColumnList[i].Add(Convert.ToDouble(dtGrid.Rows[k].Columns[i].ToString()));
		}
	}
