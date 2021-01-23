    struct Range
    {
    	public int Start, End;
    	public int Length { get { return End - Start; } }
    	public Range(int start, int length) { Start = start; End = start + length; }
    }
    
    static IEnumerable<Range[]> GetPalindromeBlocks(string input)
    {
    	int maxLength = input.Length / 2;
    	var ranges = new Range[maxLength];
    	int count = 0;
    	for (var range = new Range(0, 1); ; range.End++)
    	{
    		if (range.End <= maxLength)
    		{
    			if (IsPalindromeBlock(input, range))
    			{
    				ranges[count++] = range;
    				range.Start = range.End;
    			}
    		}
    		else
    		{
    			if (count == 0) break;
    			yield return GenerateResult(input, ranges, count);
    			range = ranges[--count];
    			if (count > 0)
    				yield return GenerateResult(input, ranges, count);
    		}
    	}
    }
    
    static bool IsPalindromeBlock(string input, Range range)
    {
    	return string.Compare(input, range.Start, input, input.Length - range.End, range.Length) == 0;
    }
    
    static Range[] GenerateResult(string input, Range[] ranges, int count)
    {
    	var last = ranges[count - 1];
    	int midLength = input.Length - 2 * last.End;
    	var result = new Range[2 * count + (midLength > 0 ? 1 : 0)];
    	for (int i = 0; i < count; i++)
    	{
    		var range = result[i] = ranges[i];
    		result[result.Length - 1 - i] = new Range(input.Length - range.End, range.Length);
    	}
    	if (midLength > 0)
    		result[count] = new Range(last.End, midLength);
    	return result;
    }
