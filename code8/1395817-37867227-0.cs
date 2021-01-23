    private static int s_Counter = 1;
    
    public static IncrementCounter () { Interlocked.Increment(ref s_Counter); }
    
    public static int Counter { get { return s_Counter; } }
