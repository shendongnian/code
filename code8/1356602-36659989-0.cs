	public static List<Dictionary<string, string>> RowEntries(string LocationAndCategory)
	{
		var lines = File.ReadAllLines(@"C:\MyFile.csv");
		var header = lines.First().Split(',');          
		int y=-1;
		
		return lines.Skip(1) //skip header.
                    .Where(line => string.Join(" ",line.Split(',').Take(2)) == LocationAndCategory)
			 		.Select(l=>l.Split(',')
		     		.ToDictionary(x=> header[(++y)%header.Count()], x=>x))
			 		.ToList();		
	}
