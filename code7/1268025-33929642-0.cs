    public static void Main()
	{
		var valueCov = new long[]{ 1,2,2,2,5,5,5,5,6,6,7,7,7};	
		var result = 0L;
		var x = 3;
		
		result = FindNextCloseset(valueCov, x, result);
		
		Console.WriteLine(result);
		
		result = FindNextCloseset(valueCov, x, result);
	
		Console.WriteLine(result);
	}
	
	public static long FindNextCloseset(long[] values, int occurrence, long searchAfterValue)
	{
		return values
            .Where(i => i > searchAfterValue)
            .GroupBy(i => i)
            .Where(i => i.Count() == occurrence)
            .Select(i => i.Key)
            .FirstOrDefault();	
	}
