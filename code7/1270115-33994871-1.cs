    private static void ThrowError(Task t)
    {
        if (t.IsFaulted)
        {
			Exception exception = 
				t.Exception.InnerExceptions != null && t.Exception.InnerExceptions.Count == 1 
					? t.Exception.InnerExceptions[0] 
					: t.Exception;
			
			ExceptionDispatchInfo.Capture(exception).Throw();
        }
    }
