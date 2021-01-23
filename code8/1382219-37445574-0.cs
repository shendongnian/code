	public static double[][] getArrayData(double[][] values, int startIndex, int endIndex)
	{
		return 
			Enumerable.Range(startIndex, endIndex)
				.Select(i => values.Select(x => x[i])
				.ToArray()
			).ToArray();
	}
