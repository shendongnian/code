    static void Main(string[] args)
    {
    	Dictionary<string, string> bands = new Dictionary<string, string>();
    	bands.Add("30 ... ... ...", "SECONDS TO MARS");
    	bands.Add("... 5", "MAROON");
        bands.Add("... STEPS ... ...", "TWO FROM HELL");
    
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
    				string[] splittedQuestion = band.Key.Split(new string[] { "..." }, StringSplitOptions.None);
    				string[] splittedAnswer = band.Value.Split(' ');
    
    				// fill splittedQuestion string with answer values
    				for (int i = 0; i < splittedAnswer.Count(); i++)
    				{
    					int currentIndex = GetNextDotIndex(splittedQuestion);
    					if (currentIndex != -1)
    					{
    						splittedQuestion[currentIndex] = splittedAnswer[i];
    					}
    				}
    
    				// build result
    				string result = "";
    				for (int i = 0; i < splittedQuestion.Count(); i++)
    				{
    					result += splittedQuestion[i].Trim().ToUpper();
    					if (i < splittedQuestion.Count() - 1)
    					{
    						result += " ";
    					}
    				}
    
    				Console.WriteLine(result);
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
    }
    
    private static int GetNextDotIndex(string[] splittedQuestion)
    {
    	for (int j = 0; j < splittedQuestion.Count(); j++)
    	{
    		if (splittedQuestion[j] == "" || splittedQuestion[j] == " ")
    		{
    			return j;
    		}
    	}
    	// return -1, when no more ... are available
    	return -1;
    }
