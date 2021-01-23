    public static void Main()
    	{
    		string inputNumber = "15647589654856987458963547589656";
    		
    		List<string> batch = new List<string>();
    		
    		string temp = "";
    		int counter = 0;
    		
    		for(int i = 0; i < inputNumber.Length; i++)
    		{	
    			
    			temp += inputNumber[i];
    			counter++;
    			if(counter == 16)
    			{
    				batch.Add(MaskString(temp));
    				counter = 0;
    				temp = "";
    			}
    		}
    		
    		
    		foreach(var b in batch)
    		{
    			Console.WriteLine(b);
    		}
    	}
    	
    	public static string MaskString(string unmaskedString)
    	{
    		var stringBuilder = new StringBuilder(unmaskedString);
    		for(int i = 4; i < 9; i++)
    		{
    			stringBuilder.Remove(i, 1);
    			stringBuilder.Insert(i, "X");
    		}
    		return stringBuilder.ToString();		
    	}
