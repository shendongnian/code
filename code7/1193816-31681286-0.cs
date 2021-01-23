    private sealed class <>c
    {
        public static readonly C.<>c <>9;
        public static WaitOrTimerCallback <>9__0_0;
        static <>c()
        {
            // Note: this type is marked as 'beforefieldinit'.
            C.<>c.<>9 = new C.<>c();
        }
        internal void <M>b__0_0(object state, bool timedOut)
        {
        }
    }
    public void M()
    {
        Mutex mutex = new Mutex();
        WaitHandle arg_2E_0 = mutex;
        WaitOrTimerCallback arg_2E_1;
        if (arg_2E_1 = C.<>c.<>9__0_0 == null)
        {
            arg_2E_1 = C.<>c.<>9__0_0 = new WaitOrTimerCallback(C.<>c.<>9.<M>b__0_0);
        }
        RegisteredWaitHandle registeredWaitHandle = 
            ThreadPool.RegisterWaitForSingleObject(arg_2E_0, arg_2E_1, null, 1000, false);
    }
