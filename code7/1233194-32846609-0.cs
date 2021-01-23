    #define COUNTDOWN_SECONDS 10
    
    private int CountDownValue = COUNTDOWN_SECONDS;
    
    private static void _timer2_Elapsed(object sender, ElapsedEventArgs e)
    {
    	WriteConsoleMessage(CountDownValue--);
    
    	if (CountDownValue == 0)
    	{
    		// Stop timer2
    		// Start timer1
    	}
    }
    
    private static void WriteConsoleMessage(int Value)
    {
    	if (Value < COUNTDOWN_SECONDS)
    		Console.CursorLeft = 0;  // Reset cursor to start of the line
    
    	Console.Write(string.Format("{0} Seconds until timer starts", Value.ToString());
    }
