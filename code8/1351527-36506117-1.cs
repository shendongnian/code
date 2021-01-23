    public class Program
    {
    	private static readonly AutoResetEvent ResetEvent = new AutoResetEvent(true);
    	
    	public static void Main()
    	{
    		Task.Run
    		(
    			() =>
    			{
                    // This would be where you want to wait until
                    // the button is pressed again
    				ResetEvent.WaitOne();
    				Console.WriteLine("This will be written once the ResetEvent has been signaled in the other thread");
    			}
    		);
    		
    		Task.Run
    		(
    			() =>
    			{
    				Thread.Sleep(5000);	
    				ResetEvent.Set();
    			}
    		);
    	}
    }
