    Dictionary<string, string> bands = new Dictionary<string, string>();
    bands.Add("30 ... ... ...", "SECONDS TO MARS");
    bands.Add("... 5", "MAROON");
    
    foreach (KeyValuePair<string, string> band in bands)
    {
    	bool solved = false;
    
    	while (!solved)
    	{
    		Console.WriteLine("current band: " + band.Key);
    
    		string input = Console.ReadLine();
    
    		if (band.Value == input.ToUpper())
    		{
    			Console.WriteLine("correct");
    			solved = true;
    		}
    		else
    		{
    			Console.WriteLine("wrong");
    		}
    	}
    }
    Console.WriteLine("finished");
    Console.ReadLine();
