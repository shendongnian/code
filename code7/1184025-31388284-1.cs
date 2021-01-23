	string[] rows = patternToLoad.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
	DataTable newDT = new DataTable();
	if(rows.Length > 0)
	{
		int numOfColumns = rows[0].Length;
		//Since the matrix is not sparse all rows have the same length, so we just create the layout
		for(int i = 0; i < numOfColumns; i++)
		{
			newDT.Columns.Add(i.ToString(), typeof(int));
		}
		//Now go through all rows in string format and fill the actual DataTable
		foreach(string currentRow in rows)
		{
			DataRow newRow = newDT.NewRow();
			for(int j = 0; j < numOfColumns; j++)
			{
				newRow[j] = currentRow[j] = '1' ? 1 : 0;
			}
			newDT.Rows.Add(newRow);
		}
	}
	
