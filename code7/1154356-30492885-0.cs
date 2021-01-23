    void Main()
    {
    	Console.WriteLine (ReorderInt32Digits2(2927466));
    	Console.WriteLine (ReorderInt32Digits2(12492771));		
    	Console.WriteLine (ReorderInt32Digits2(-1024));
    }
    
    public static int ReorderInt32Digits2(int v)
    {
    	bool neg = (v < 0);
    	int mult = neg ? -1 : 1;
    	int result = 0;
    	var counts = GetDigitCounts(v);
    	for (int i = 0; i < 10; i++)
    	{
    		int idx = neg ? 9 - i : i;
    		for (int j = 0; j < counts[idx]; j++)
    		{
    			result += idx * mult;
    			mult *= 10;			
    		}
    	}
    	return result;
    }
    
    // From Atul Sikaria's answer
    public static int[] GetDigitCounts(int n)
    {
    	int v = Math.Abs(n);
    	var result = new int[10];
    	while (v > 0) {
    		int digit = v % 10;
    		v = v / 10;
    		result[digit]++;
    	}
    	return result;
    }
