    private static List<List<string>> FilterData(List<List<string>> datatable)
	{
		var result = new List<List<string>>();
		
		for(var rowindex = 0; rowindex < datatable.Count; rowindex++)
		{
            // Clone the string list
			var refrow = datatable[rowindex]
                .Select(item => (string)item.Clone()).ToList(); 
			
			result.Add(refrow);
            // First row will not get modify anyway
			if (rowindex == 0) continue;
			var row = result[rowindex];
            // previous row of result has changed to "-", so use the original row to compare
			var prevrow = datatable[rowindex - 1]; 
			for(var columnindex = 0; columnindex < row.Count; columnindex++)
			{
				if (row[columnindex] == prevrow[columnindex])
					row[columnindex] = "-";
			}
		}
		
		return result;
	}
