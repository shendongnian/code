    // this method does the calculations then puts the values in the totalScore and totaltime variables
	public void DoCalculations(string[,] data, string id, out int totalScore, out int totalTime)
	{
		totalTime = 0;
		totalScore = 0;
		for (int i = 0; i < data.Length/4; i++)
		{
			if (data[i, 0] != id) continue;
            
            // modify this string to contain the lessons between E and I
			if (!"EFGHI".Contains(data[i, 1])) continue;
            // do proper error checking unless you're sure they'll always be integers
			totalTime += int.Parse(data[i, 2]);
			totalScore += int.Parse(data[i, 3]);
		}
	}
