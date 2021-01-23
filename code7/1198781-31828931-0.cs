	static void Main(string[] args)
	{
		
		// Input:
		String[] values = { "A1", "B1", "C1", "5" };
		
		// Results:
		String[] numbers = (from x in values where StringContainsNumbersOnly(x) select x).ToArray();
		String[] cells = (from x in values where !numbers.Contains(x) select x).ToArray();
	}
	static bool StringContainsNumbersOnly(string inputString)
	{
		return System.Text.RegularExpressions.Regex.IsMatch(inputString, @"^\d+$");
	}
