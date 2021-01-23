    internal static void Assert(bool condition, string invariantMessage)
    {
    	if (!condition)
    	{
    		Invariant.FailFast(invariantMessage, null);
    	}
    }
