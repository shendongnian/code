	public static void Main()
	{
		ulong x = 13;
    	while(x > 0)
    	{
    		ulong bit = x & ~(x-1);
    		x = x & (x-1);
	    	Console.WriteLine("bit-value {0} is set", bit);
		}
	}
