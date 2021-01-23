    List<string> output = new List<string>();
    string input = "(\"always use\" OR \"bar\") OR (\"Hello\" AND \"market cost\")OR((\"IT\"AND\"P T\")AND(\"PO\"NOT\"pop good\"))";
    var openSplit = input.Split('(');
    for (int i = 0; i < openSplit.Length; i++)
    {
    	if (openSplit[i] == "")
    	{
    		// put a '(' on
    		output.Add("(");
    	}
    	else
    	{
    		var closeSplit = openSplit[i].Split(')');
    		for (int j = 0; j < closeSplit.Length; j++)
    		{
    			var quoteSplit = closeSplit[j].Split('"');
    			foreach (var quote in quoteSplit)
    			{
    				if (quote != "")
    				{
    					output.Add(quote.Trim());
    				}
    			}
    			// put a ')' on the end, but not if it's the last one
    			if (j < closeSplit.Length - 1)
    			{
    				output.Add(")");
    			}
    		}
    		// put a '(' on the end, but not if it's the last one
    		if (i < openSplit.Length - 1)
    		{
    			output.Add("(");
    		}
    	}
    }
