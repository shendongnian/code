    class Program
    {
        public void Main(string[] args)
        {
            uint timerId = SafeNativeMethods.timeSetEvent( 1, 1, HandleTimerTick, UIntPtr.Zero, 1 );
            Console.ReadLine();
            SafeNativeMethods.timeKillEvent( timerId );
        }
        
        public static void HandleTimerTick( uint id, uint msg, UIntPtr userCtx, UIntPtr uIntPtr, UIntPtr intPtr )
        {
        	Console.WriteLine( "This is a bad idea on short timescales" );
        }
    }
        
    public static class SafeNativeMethods
    {
    	/// <summary>
    	/// A timer event handler
    	/// </summary>
    	/// <param name="id">Timer identifier, as returned by the timeSetEvent function.</param>
    	/// <param name="msg">Reserved</param>
    	/// <param name="userCtx">The value that was passed in to the userCtx value of the timeSetEvent function.</param>
    	/// <param name="dw1">Reserved</param>
    	/// <param name="dw2">Reserved</param>
    	public delegate void TimerEventHandler( UInt32 id, UInt32 msg, UIntPtr userCtx, UIntPtr dw1, UIntPtr dw2 );
      	/// <summary>
    	/// A multi media timer with millisecond precision
    	/// </summary>
    	/// <param name="msDelay">One event every msDelay milliseconds</param>
    	/// <param name="msResolution">Timer precision indication (lower value is more precise but resource unfriendly)</param>
    	/// <param name="handler">delegate to start</param>
    	/// <param name="userCtx">callBack data </param>
    	/// <param name="eventType">one event or multiple events</param>
    	/// <remarks>Dont forget to call timeKillEvent!</remarks>
    	/// <returns>0 on failure or any other value as a timer id to use for timeKillEvent</returns>
    	[DllImport( "winmm.dll", SetLastError = true, EntryPoint = "timeSetEvent" )]
    	public static extern UInt32 timeSetEvent( UInt32 msDelay, UInt32 msResolution, TimerEventHandler handler, UIntPtr userCtx, UInt32 eventType );
       
    	/// <summary>
    	/// The multi media timer stop function
    	/// </summary>
    	/// <param name="uTimerID">timer id from timeSetEvent</param>
    	/// <remarks>This function stops the timer</remarks>
    	[DllImport( "winmm.dll", SetLastError = true )]
    	public static extern void timeKillEvent( UInt32 uTimerID );
    }
