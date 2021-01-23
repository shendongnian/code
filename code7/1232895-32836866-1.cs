    int spacelimit = 13, num = 1, n = 5;
    for(int i = 1; i <= n; i++)
    {
    	for(int space = spacelimit; space >= i; space--)
    	{
    		Console.Write(" ");
    	}
    	for(int k = 1; k <= i; k++)
    	{
    		Console.Write("{0,2:D} ", num++);
    	}
    	spacelimit = spacelimit - 2;
    	Console.WriteLine();
    }
    Console.ReadKey();
