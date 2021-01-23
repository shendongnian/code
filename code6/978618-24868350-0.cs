    class Program
    {
    //declare your class variables here
    //so that you can access them from the methods and do your operations
        static void Main(string[] args)
    	{
    		Console.WriteLine("Program started.");
    		bool Up=true;
    		ThreadPool.QueueUserWorkItem(ConsoleCommands);
    		while (Up)
    		{
    			Thread.Sleep(2000);
    		}
    		Console.WriteLine("Program ended.");
    	}
    
    	private void ConsoleCommands(object dummy)
    	{
    		while (Up)
    		{
    			string cmd = ConsoleReceiver().ToLower();
    			switch (cmd)
    			{
    				case "exit":
    					Up=false;
    					break;
    				//implement more cases here and fill the rest of your business
    				//example:
    				case "1":
    					if (pos.Count == Int32.Parse(cmd))//just a dummy business
    					{
    						Console.WriteLine("Sorry this number does not match");
    					}
    					else//another dummy business
    					{
    						Console.WriteLine("Sth...");
    					}
    					break;
    				default:
    					Console.WriteLine("Unrecognized command");
    					break;
    			}//or forget about switch and use if-else stements instead.
    		}
    	}
    
    	private string ConsoleReceiver()
    	{
    		Console.WriteLine("#cmd:");
    		return Console.ReadLine();
    	}
    }
