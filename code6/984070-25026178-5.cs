    foreach(var v in result.GetType().GetProperties())
    {
    	if(v.DeclaringType == result.GetType())
    	{
    		Console.WriteLine(v.GetValue(result));
    	}
    }
