    public static void Main(string[] args)
    {
    	if(args!= null && args.Length >0)
    	{
    		// Read parameters as args[0]. args[1] etc...
    	}
    	else
    	{
            // if there are no commandline parameters/arguments.
    		var input = Console.ReadLine(); // Read's user input.
    		
    		for(int i=0;i<3;i++) // Since you want to print user input 3 times,you can do this way. 
    		{
    			Console.WriteLine(input);
    		}			
    	}		    	
    }
