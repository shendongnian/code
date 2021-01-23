    private static SynchronizationContext GetThreadLocalContext()
        {
            SynchronizationContext context = null;
            
    #if FEATURE_APPX
            if (context == null && Environment.IsWinRTSupported)
                context = GetWinRTContext();
    #endif
 
            return context;
        }
