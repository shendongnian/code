	static double CalculateEntropy(FileInfo file)
	{
		int range = byte.MaxValue + 1; // 0 -> 256
		byte[] values = File.ReadAllBytes(file.FullName);
		long[] counts = new long[range];
		foreach (byte value in values)
		{
			counts[value] = counts[value] + 1;
		}
		double entropy = 0;
		foreach (long count in counts)
		{
			if (count != 0)
			{
				double probability = (double)count / values.LongLength;
				entropy -= probability * Math.Log(probability, range);
			}
		}
		return entropy;
	}
