	public IEnumerable<Tuple<int, int>> GetData()
	{
		using (var fileStream = File.OpenRead(@"C:\Temp\MyData.txt"))
		{
			using (var streamReader = new StreamReader(fileStream))
			{
				string line;
				while ((line = streamReader.ReadLine()) != null)
				{
					var split = line.Split(',');
					var a = Convert.ToInt32(split[0]);
					var b = Convert.ToInt32(split[1]);
					
					// Since this is using a 'yield' each one of these is lazy-loaded.
					yield return new Tuple<int, int>(a, b);
				}
			}
		}
	}
	public void CalculateSumAndAverage()
	{
		var sumA = 0;
		var sumB = 0;
		var average = 0;
		
		foreach (var t in GetData())
		{
			sumA += t.Item1;
			sumB += t.Item2;
		}
		// I'm not a big fan of ternary operators,
		// but feel free to convert this if you so desire.
		if (sumB != 0)
		{
			average = sumA / sumB;
		}
        else 
        {
            // This else clause is redundant, but I converted it from a ternary operator.
            average = 0;
        }
	}
