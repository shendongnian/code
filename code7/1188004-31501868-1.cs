	var sb = new Stringbuilder();
	foreach (DataRow row in table.Rows)
	{
		int id = Convert.ToInt32(row["stationid"]);
		var max = Math.Max(9999, table.Rows.Count);
	
		for (int i = 1000; i < max; ++i)
		{
			if (i != id)
				sb.AppendLine().Append(i);
		}
	}
	
	stationIdsTb.Text = sb.ToString();
