    IEnumerable<string> GetFileLetters()
    {
    	const string theLetters = " abcdefghjklmnopqrstuvwxyz"; // there is no 'i'.
    	
    	for (int i = 0; ; i++)
    	{
    		var s = "";
    		var c = i;
    		do
    		{
    			s = theLetters[c % theLetters.Length] + s;
    			c = c / theLetters.Length;
    		}
    		while (c > 0);
    
    		yield return s;
    	}
    }
