	DataTable dt = new DataTable();
	var sums = new Dictionary<DateTime, int>();
	
	foreach(DataRow dr in dt.Rows)
	{
		int sum = 0;
		for(int i = 1; i < dr.ItemArray.Length; i++)
		{
			sum += (int)dr.ItemArray[i];
		}
		
		sums.Add((DateTime)dr.ItemArray[0], sum);
	}
