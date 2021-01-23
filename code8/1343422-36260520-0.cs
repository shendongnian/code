    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern uint SetThreadExecutionState(uint esFlags);
    public const uint ES_CONTINUOUS = 0x80000000;
    public const uint ES_SYSTEM_REQUIRED = 0x00000001;
    public const uint ES_AWAYMODE_REQUIRED = 0x00000040;
    
    public void AllowStandbyMode(bool allow)
    {
    	if (allow)
    	{
    		// Set state back to normal
    		SetThreadExecutionState(ES_CONTINUOUS);
    	}
    	else
    	{
    		// Try this for vista, it will fail on XP
    		if (SetThreadExecutionState(ES_CONTINUOUS | ES_SYSTEM_REQUIRED | ES_AWAYMODE_REQUIRED) == 0)
    		{
    			// Try XP variant as well just to make sure 
    			SetThreadExecutionState(ES_CONTINUOUS | ES_SYSTEM_REQUIRED);
    		}	 
    	}
    }
