    void Main()
    {
    	var input = Enumerable.Range(1, 35).Select(e => "Line: " + e).ToList();
    	
    	Console.WriteLine("------------------------------------------------");
    	Console.WriteLine("THE HEADER");
    	Console.WriteLine("------------------------------------------------");
    	
    	foreach (var element in GetLines(input))
    		Console.WriteLine(element);
    }
    
    IEnumerable<string> GetLines(IList<string> input, int maxLines = 10)
    {
    	for (int i = 0; i < input.Count; i++)
    	{
    		yield return input[i];
    		
    		if (i == maxLines - 5 && input.Count > maxLines)
    		{
    			yield return " . . . .";
    			yield return " . . . .";
    			yield return " . . . .";
    			yield return input[input.Count - 1];
    			yield break;
    		}
    	}
    }
