    public static void Main()
    {
    	var numbers = GetNumbers(2);
    	
    	var result = numbers.Take(1);
    	
    	// Evaluate only first number
    	result.ToArray();		
    }
    
    public static IEnumerable<int> GetNumbers(int max)
    {
    	for(int i = 0; i < max; i++) 
    	{
    		Console.WriteLine("Returning {0}", i); 
    		yield return i;
    	}
    }
