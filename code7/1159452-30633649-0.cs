    static IEnumerable<String> splitSpecial(string input)
    {
    	StringBuilder builder = new StringBuilder();
    	int openParenthesisCount = 0;
    
    	foreach (char c in input)
    	{
    		if (openParenthesisCount == 0 && c == '|')
    		{
    			yield return builder.ToString();
    			builder.Clear();
    		}
    		else
    		{
    			if (c == '(')
    				openParenthesisCount++;
    			if (c == ')')
    				openParenthesisCount--;
    			builder.Append(c);
    		}
    	}
    	yield return builder.ToString();
    }
    static void Main(string[] args)
    {
    	string input = "[Testing.User]|Info:([Testing.Info]|Name:([System.String]|Matt)|Age:([System.Int32]|21))|Description:([System.String]|This is some description)";
    	foreach (String split in splitSpecial(input))
    	{
    		Console.WriteLine(split);
    	}
    	Console.ReadLine();
    }
    //Ouput:
    //
    //[Testing.User]
    //Info:([Testing.Info]|Name:([System.String]|Matt)|Age:([System.Int32]|21))
    //Description:([System.String]|This is some description)
