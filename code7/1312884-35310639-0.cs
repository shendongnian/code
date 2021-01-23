    using System;
    
    namespace arrtest
    {
        class Program
        {
    	    public static void Main(string[] args)
		    {
	    		Console.WriteLine("Is64BitProcess :"+  Environment.Is64BitProcess);
			    int [] arr = new int[13805*55223];
		    	Console.Write("Press any key to continue . . . ");
	    		Console.ReadKey(true);
	    	}
	    }
    }
