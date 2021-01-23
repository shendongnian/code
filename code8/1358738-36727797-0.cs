    static void Main(string[] args)
    {
    
    	int[] arr = { 3, 6, 4, 1, 3, 4, 2, 5, 3, 0 };
    	var result = Solveable(new[] {0}, arr);
    
    
    	Console.WriteLine(result);
    	Console.ReadLine();
    }
    
    static bool Solveable(int[] path, int[] arr)
    {
    	var index = path.Last();
    
    	if (arr[index] == 0)
    		return true;
    	if (index + arr[index] < arr.Length)
    	{
    		var nextIndex = index + arr[index];
    		var nextStepPath = path.Concat(new[] { nextIndex }).ToArray();
    
    		if (path.Contains(nextIndex))
    			return false;
    
    		return Solveable(nextStepPath, arr);									  
    	}
    	if (index - arr[index] >= 0)
    	{
    		var nextIndex = index - arr[index];
    		var nextStepPath = path.Concat(new[] {nextIndex}).ToArray();
    
    		if (path.Contains(nextIndex))
    			return false;
    
    		return Solveable(nextStepPath, arr);
    	}
    
    	return false;
    }
