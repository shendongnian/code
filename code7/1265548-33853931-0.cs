    using System;
    
    public class Test
    {
    	public static void Main()
    	{
    		int n = 1;
            for (int i = 1; i <= 50; i++) {
                n *= i;
                Console.WriteLine("i = {0}, n = {1}", i, n);
            }
    	}
    }
