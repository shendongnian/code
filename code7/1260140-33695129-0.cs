	[Pure]
	private static double Sum(this double[] source, int startIndex, int endIndex)
	{
		Console.WriteLine("{0}, {1}", startIndex, endIndex);
		double sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0;
		checked
		{
			int i;
			for (i = startIndex; i < endIndex - Constants.Step + 1; i += Constants.Step)
			{
				sum1 += source[i];
				sum2 += source[i + 1];
				sum3 += source[i + 2];
				sum4 += source[i + 3];
			}
			if (i == source.Length)
				return ((sum1 + sum2) + (sum3 + sum4));
			if (i == source.Length - 1)
				return ((sum1 + sum2) + (sum3 + sum4) + source[i]);
			if (i == source.Length - 2)
				return ((sum1 + sum2) + (sum3 + sum4) + (source[i] + source[i + 1]));
			return ((sum1 + sum2) + (sum3 + sum4) + (source[i] + source[i + 1] + source[i + 2]));
		}
	}
