		public List<List<decimal>> Solve(decimal transactionAmount, decimal[] elements)
	{
		int combinations = Convert.ToInt32(Math.Pow(2.0, elements.Length));
		List<List<decimal>> results = new List<List<decimal>>();
		List<decimal> result = new List<decimal>();
		decimal bestResult = elements.Sum();
		for (int j = 0; j < combinations; j++)
		{
			string bitArray = Convert.ToString(j, 2).PadLeft(elements.Length, '0');
			decimal sum = 0;
			for (int i = 0; i < elements.Length; i++)
			{
				sum += bitArray[i].Equals('1') ? elements[i] : 0;
				if (sum > bestResult)
					break;
			}
			if (sum > bestResult || sum < transactionAmount)
				continue;
			result.Clear();
			result.AddRange(elements.Where((t, i) => bitArray[i].Equals('1')));
			bestResult = result.Sum();
			//Perfect result
			if (sum == transactionAmount)
				results.Add(new List<decimal>(result));
		}
		// Get last solution
        if (results.All(x => result.Except(x).ToList().Count != 0))
            results.Add(new List<decimal>(result));
		return results;
	}
