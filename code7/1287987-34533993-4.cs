	public IEnumerable<string> GetData()
	{
		using (var fileStream = File.OpenRead(@"C:\Temp\MyData.txt"))
		{
			using (var streamReader = new StreamReader(fileStream))
			{
				string line;
				while ((line = streamReader.ReadLine()) != null)
				{						
                    yield return line;
				}
			}
		}
	}
	public void CalculateSumAndAverage()
	{
		var sumA = 0;
		var sumB = 0;
		var average = 0;
		
		foreach (var line in GetData())
		{
            var split = line.Split(',');
            var a = Convert.ToInt32(split[0]);
            var b = Convert.ToInt32(split[1]);
			
            sumA += a;
			sumB += b;
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
