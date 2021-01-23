    void Main()
    {
    	var start = "IHaveADream";
    	var input = "ByeByeByeByeBye";
    	
    	var sb = new StringBuilder(start.Length + input.Length);
    	
    	var length = start.Length >= input.Length ? start.Length : input.Length;
    	for (int i = 0; i < length; i++)
    	{
    		if (start.Length >= i + 1)
    			sb.Append(start[i]);
    		
    		if (input.Length >= i + 1)
    			sb.Append(input[i]);
    	}
    	
    	sb.ToString().Dump();
    }
