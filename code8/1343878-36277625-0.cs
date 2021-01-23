    static void Main(string[] args)
    {
    	Dictionary<string, string> bands = new Dictionary<string, string>();
    	bands.Add("30 SECONDS TO MARS", "30 ... ... ...");
    	bands.Add("MAROON 5", "... 5");
    
    	foreach (KeyValuePair<string, string> band in bands)
    	{
    		Console.WriteLine("Current band: " + band.Value);
    
    		string[] splittedBand = band.Value.Split(new string[] { "..." }, StringSplitOptions.None);
    
    		string input = Console.ReadLine();
    		string[] splittedInput = input.Split(' ');
    
    		// fill splittedBand string with values
    		for (int i = 0; i < splittedInput.Count(); i++)
    		{
    			int currentIndex = GetNextDotIndex(splittedBand);
    			if (currentIndex != -1)
    			{
    				splittedBand[currentIndex] = splittedInput[i];
    			}
    		}
    
    		// build result
    		string result = "";
    		for (int i = 0; i < splittedBand.Count(); i++)
    		{
    			result += splittedBand[i].Trim().ToUpper();
    			if (i < splittedBand.Count() - 1)
    			{
    				result += " ";
    			}
    		}
    
    		Console.WriteLine("Generated output: " + result);
    		if (band.Key == result)
    		{
    			Console.WriteLine("correct");
    		}
    		else
    		{
    			Console.WriteLine("wrong");
    		}
    	}
    	Console.ReadLine();
    }
    
    private static int GetNextDotIndex(string[] splittedBand)
    {
    	for (int j = 0; j < splittedBand.Count(); j++)
    	{
    		if (splittedBand[j] == "" || splittedBand[j] == " ")
    		{
    			return j;
    		}
    	}
    	// return -1, when no more ... are available
    	return -1;
    }
