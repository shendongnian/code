    public static SynchronizationContext Current 
        {
            get      
            {
                return Thread.CurrentThread.GetExecutionContextReader().SynchronizationContext ?? GetThreadLocalContext();
            }
        }
