    static void Main(string[] args)
    {
    	Console.WriteLine(String.Join(Environment.NewLine, printPossibilities("qwerty")));
    }
    
    private static List<string> printPossibilities(string str)
    {
    	List<string> allPossibilities = new List<string>();
    	List<bool> binarycount = new List<bool>();
    	for (int i = 0; i < str.Length - 1; i++) {
    		binarycount.Add(false);
    	}
    
    	bool hasNext = true;
    	while(hasNext)
    	{
    		string temp = str;
    		for (int i = binarycount.Count - 1; i >= 0; i--)
    		{
    			if (binarycount[i])
    				temp = temp.Insert(i+1, ".");
    		}
    		allPossibilities.Add(temp);
    		hasNext = false;
    		for (int i = binarycount.Count - 1; i >= 0; i--)
    		{
    			if (binarycount[i]) {
    				binarycount[i] = false;
    			} else {
    				binarycount[i] = true;
    				hasNext = true;
    				break;
    			}
    		}
    	}
    	return allPossibilities;
    }
