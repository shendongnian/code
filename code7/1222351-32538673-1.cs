    public static void Main()
    	{
    		string temp = "";
    		int counter = 0;
    		string inputNumber = "15647589654856987458963547589656";
    		
    		List<string> batch = new List<string>();
    		
    		for(int i = 0; i < inputNumber.Length; i++)
    		{	
    			counter++;
    			temp += inputNumber[i];
    			if(counter >= 16)
    			{
    				batch.Add(MaskedString(temp));
    				counter = 0;
    				temp = "";
    			}
    		}
    
    		foreach(var b in batch)
    		{
    			Console.WriteLine(b);
    		}
    	}
    	
    	public static string MaskedString(string unmaskedString)
    	{
    		var stringBuilder = new StringBuilder(unmaskedString);
    		
    		for(int i = 4; i < 9; i++)
    		{
    			stringBuilder.Remove(i, 1);
    			stringBuilder.Insert(i, "X");
    		}
    		
    		return stringBuilder.ToString();		
    	}
