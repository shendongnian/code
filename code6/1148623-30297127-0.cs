    System.Diagnostics.Stopwatch
    class Program
    {
        static void Main()
        {
    	// Create new stopwatch
    	Stopwatch stopwatch = new Stopwatch();
    
    	// Begin timing
    	stopwatch.Start();
    
    	// Do something   	
    
    	// Stop timing
    	stopwatch.Stop();
    
    	// Write result
    	Console.WriteLine("Time elapsed: {0}",
    	    stopwatch.Elapsed);
        }
    }
