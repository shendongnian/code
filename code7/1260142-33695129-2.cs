		[Pure]
	public static double Sum(this double[] source, int startIndex, int endIndex)
	{
		double sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0;
		checked
		{
			int i;
			int j = 0;
			for (i = startIndex; i < endIndex - Constants.Step + 1; i += Constants.Step)
			{
				sum1 += source[i];
				sum2 += source[i + 1];
				sum3 += source[i + 2];
				sum4 += source[i + 3];
				j += Constants.Step;
			}
			var segmentLength = endIndex - startIndex;
			
			if (j == segmentLength)
				return ((sum1 + sum2) + (sum3 + sum4));
			if (j == segmentLength - 1)
				return ((sum1 + sum2) + (sum3 + sum4) + source[i]);
			if (j == segmentLength - 2)
				return ((sum1 + sum2) + (sum3 + sum4) + (source[i] + source[i + 1]));
			return ((sum1 + sum2) + (sum3 + sum4) + (source[i] + source[i + 1] + source[i + 2]));
		}
	}
	
	internal static class Constants
	{
		public const int Step = 4;
		public const int SingleThreadExecutionThreshold = 1024;
	}
		
	[Pure]
	public static double Sum(this double[] source)
	{
		if (source.Length < Constants.SingleThreadExecutionThreshold)
			return Sum(source, 0, source.Length);
		double result = 0;
		object syncRoot = new object();     
		Parallel.ForEach(Partitioner.Create(0, source.Length),
			(range) => {
			
				var x = Sum(source, range.Item1, range.Item2);
				lock (syncRoot)
					result += x;
			});
		return result;
	}
