	void Main()
	{
		string[,] options = new string[100,3];
		
		options[0,0] = "bleb";
		options[1,1] = "bleb";
		options[2,0] = "bleb";
		options[2,1] = "bleb";
		options[3,2] = "bleb";
		options[4,1] = "bleb";
		
		string[,] trimmed = TrimAfterNullRow(options);
		
		Console.WriteLine(trimmed);
	}
	
	public string[,] TrimAfterNullRow(string[,] options) 
	{
		IList<string[]> nonNullRows = new List<string[]>();
		for (int x = 0; x < options.GetLength(0); x++) 
		{
			bool allNull = true;
			
			var row = new string[options.GetLength(1)];
			
			for (int y = 0; y < options.GetLength(1); y++) 
			{
				row[y] = options[x,y];
				allNull &= options[x,y] == null;
			}
			
			
			if (allNull) 
			{
				break;
			} 
			else 
			{
				nonNullRows.Add(row);
			}
		}
		
		var optionsTrimmed = new string[nonNullRows.Count, options.GetLength(1)];
		
		for (int i=0;i<nonNullRows.Count;i++)
		{
			for (int j=0;j<options.GetLength(1);j++)
			{
				optionsTrimmed[i, j] = nonNullRows[i][j];
			}
		}
		
		
		return optionsTrimmed;
	}
