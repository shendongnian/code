	public static string GetValue(this DataSet dataSet, int n)
	{
		if (dataSet.Tables.Contains("Table" + n) 
		{
			var dataRow = dataSet.Tables["Table" + n].Select();
			if (dataRow.Length > 0) 
			{
				return = dataRow[0]["value" + n].ToString()
			}
		}
			
		return string.Empty;
	}
	public void method1(DataSet dataSet) 
	{
		var value1 = dataSet.GetValue(1);
	}
