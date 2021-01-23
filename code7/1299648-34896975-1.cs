    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    public void ReleaseMutex()
    {
        if (!Win32Native.ReleaseMutex(base.safeWaitHandle))
        {
            throw new ApplicationException(Environment.GetResourceString("Arg_SynchronizationLockException"));
        }
        Thread.EndCriticalRegion();
        Thread.EndThreadAffinity();
    }
