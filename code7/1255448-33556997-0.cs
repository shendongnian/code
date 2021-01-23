    public static int GetIndex()
    {
    			const string input = "010000111";
    			const string substring = "10000111";
    
    			var startIndex = input.IndexOf(substring);
    			if (startIndex != -1)
    			{
    				return startIndex + substring.Length;
    			}
    
    			return -1;
    }
