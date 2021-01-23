	for (int i = 0; i < compiledAssays.Length; i++)
	{
		for (int j = i + 1; j < compiledAssays.Length; j++)
		{
			if (compiledAssays[i].Overlaps(compiledAssays[j]))
			{
				throw new ApplicationException("Something went wrong.");
			}
		}
	}
