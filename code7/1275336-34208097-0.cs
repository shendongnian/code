    static void GeneratePrbSsequences(int v1, int v2)
    {
    	int a = 0x02;
    	int period = (int)(Math.Pow(2, v1) - 1);
     	v1--;
    	v2--;
    	for (int i=1;;i++)
    	{
    		var newbit = (((a >> v1) ^ (a >> v2)) & 1);
    		System.Diagnostics.Debug.Write(newbit);
    		if (i%8 == 0) 
    		{
    			System.Diagnostics.Debug.Write(" ");
    			if (i%128 == 0) System.Diagnostics.Debug.WriteLine("");
    		}
    		a = ((a << 1) | newbit) & period;
    		if (a == 0x02)
    		{
    			System.Diagnostics.Debug.WriteLine("");
    			System.Diagnostics.Debug.WriteLine("Computed period = {0}, Actual period = {1}", period, i);
    			break;
    		}
    	}
    }
