    class Program
    	{
    		static bool continueRun = true;
    		static void Main(string[] args)
    		{
    			System.AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;
    
    			try
    			{
    				Console.WriteLine("Enter code");
    				Task.Run(() =>
    				{
    					Console.WriteLine("Enter task");
    					System.Threading.Thread.Sleep(1000);
    					Console.WriteLine("End thread sleep");
    					throw new Exception("Inner task execution");
    				});
    				Console.WriteLine("Exit code");
    			}
    			catch (Exception err)
    			{
    				Console.WriteLine("Exception code");
    			}
    			finally
    			{
    				Console.WriteLine("Finally code");
    			}
    
    			 
    			Console.WriteLine("Press a key to exit");
    			Console.ReadLine();
    		}
    
    		private static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
    		{
    			Console.Write("Unhandled exception");
    			continueRun = false;
    			Console.ReadLine();
    		}
    	}
