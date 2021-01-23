    private void ThreadProc()
    {
        // Attach scheduler to thread
        __attachedScheduler.Value = this;
        try
        {
            // TODO: Actual thread proc goes here...
        }
        finally
        {
            // Detach scheduler from thread
            __attachedScheduler.Value = null;
        }
    }
