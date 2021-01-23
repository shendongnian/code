	public static List<Dictionary<string, string>> RowEntries(string LocationAndCategory)
	{
		var lines = File.ReadAllLines(@"C:\MyFile.csv");
		var header = lines.First().Split(',');          
		int y=-1;
		
		return lines.Skip(1) //skip header.
                    // Split string and take only first two strings to compare with LocationAndCategory.
                    .Where(line => string.Join(" ",line.Split(',').Take(2)) == LocationAndCategory) 
                    // Split each line by ',' and convert to dictionary.
			 		.Select(l=>l.Split(',').ToDictionary(x=> header[(++y)%header.Count()], x=>x))
			 		.ToList();		
	}
