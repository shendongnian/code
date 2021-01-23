	var sb = new Stringbuilder();
	foreach (DataRow row in table.Rows)
	{
		int id = Convert.ToInt32(row["stationid"]);
	
		for (int i = 1000; i < 9999 - table.Rows.Count; i = i++)
		{
			if (i != id)
				sb.AppendLine().Append(i);
		}
	}
	
	stationIdsTb.Text = sb.ToString();
	 
