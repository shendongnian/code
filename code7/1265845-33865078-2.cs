    public static void Main(string[] args)
    {
    
        //Func<int> is saying I want a function with no parameters
        //but returns an int. '() =>' this represents a function with 
        //no parameters. It then points to your defined method ThreadMethod
        //Which fits the notions of no parameters and returning an int.
    
    	Func<int> threadMethod = () => ThreadMethod();
    	
    	Task<int> t = Task.Run(threadMethod);
    	Console.WriteLine(t.Result);
    }
    
    public static int ThreadMethod()
    {
    	return 42;
    }
