    public enum Operation
    {
    	 And,
    	 Or
    }
    public static bool Contains(this string text,Operation operation,params string[] args) 
     {
    	switch(operation)
    	{
    		case Operation.And:
    			return args.All(item => text.Contains(item));
    		case Operation.Or:
    			return args.Any(item => text.Contains(item));
    		default:
    			return false;
    	}
     }
