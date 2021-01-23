    class Program
    {
    	static void Main(string[] args)
    	{
    		DateTime StartTime;
    		DateTime EndTime;
    		TimeSpan ExecutionTime;
    
    		StartTime = DateTime.Now;
    		for (int i = 0; i < 10000;)
    		{
    			i++;
    			for (int j = 0; j < 100000;)
    			{
    				j++;
    			}
    		}
    		EndTime = DateTime.Now;
    		ExecutionTime = (EndTime - StartTime);
    
    		Console.WriteLine("Phase 1 without comment done.");
    		Console.WriteLine("Phase 1 start time : " + StartTime.ToString());
    		Console.WriteLine("Phase 1 end time : " + EndTime.ToString());
    		Console.WriteLine("Phase 1 Execution Seconds : " + ExecutionTime.TotalSeconds);
    
    		Console.WriteLine("\r\n---------------------------------------------\r\n");
    
    		StartTime = DateTime.Now;
    		for (int i = 0; i < 10000;)
    		{
    			i++;
    			for (int j = 0; j < 100000;)
    			{
    				j++;
    				// SOME COMMENT.
    				// SOME COMMENT.
    				// SOME COMMENT.
    				// SOME COMMENT.
    				// SOME COMMENT.
    				// SOME COMMENT.
    				// SOME COMMENT.
    				// SOME COMMENT.
    				// SOME COMMENT.
    				// SOME COMMENT.
    				// SOME COMMENT.
    				// SOME COMMENT.
    				// SOME COMMENT.
    				// SOME COMMENT.
    				// SOME COMMENT.
    				// SOME COMMENT.
    				// SOME COMMENT.
    				// SOME COMMENT.
    				// SOME COMMENT.
    				// SOME COMMENT.
    				// SOME COMMENT.
    			}
    		}
    		EndTime = DateTime.Now;
    		ExecutionTime = (EndTime - StartTime);
    
    		Console.WriteLine("Phase 2 with comment done.");
    		Console.WriteLine("Phase 2 start time : " + StartTime.ToString());
    		Console.WriteLine("Phase 2 end time : " + EndTime.ToString());
    		Console.WriteLine("Phase 2 Execution Seconds : " + ExecutionTime.TotalSeconds);
    
    		Console.ReadKey();
    	}
    }
