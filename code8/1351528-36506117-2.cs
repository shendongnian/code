    public class Program
    {
        // AutoResetEvent constructor argument is if the event should be start
        // signaled or not.
        //
        // A ResetEvent is like a door. If it's signaled, the door is open,
        // and if it's not signaled, the door is closed.
    	private static readonly AutoResetEvent ResetEvent = new AutoResetEvent(false);
    	
    	public static void Main()
    	{
    		Task.Run
    		(
    			() =>
    			{
    				Thread.Sleep(3000);
                    // Calling Set() is signaling the event. That is, 
                    // you open the door. And other threads waiting until
                    // the door is opened get resumed.
    				ResetEvent.Set();
    			}
    		);
    		
            // Since the ResetEvent isn't signaled, the door is closed
            // and it'll wait until the door gets opened (i.e. the event
            // gets signaled).
    		ResetEvent.WaitOne();
    		Console.WriteLine("This will be written once the ResetEvent has been signaled in the other thread");
    	}
    }
