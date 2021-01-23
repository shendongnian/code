    public static int EstimateLineCount(string file)
	{
		using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
		{
			return EstimateLineCount(fs);
		}
	}
	public static int EstimateLineCount(Stream s)
	{
		//if file is larger than 10MB estimate the line count, otherwise get the exact line count
		const int maxBytes = 10485760; //10MB = 1024*1024*10 bytes
		s.Position = 0;
		using (var sr = new StreamReader(s, Encoding.UTF8))
		{
			int lineCount = 0;
			if (s.Length > maxBytes)
			{
				while (s.Position < maxBytes && sr.ReadLine() != null)
					lineCount++;
				return Convert.ToInt32((double)lineCount * s.Length / s.Position);
			}
			while (sr.ReadLine() != null)
				lineCount++;
			return lineCount;
		}
	}
