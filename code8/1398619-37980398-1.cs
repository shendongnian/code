    // test code
    RunSafeDelegate rsd1 = () => { /* some code i need synchronous */ };
    RunSafeDelegate rsd2 = () => { /* other code i need synchronous */ };
    var util = new UtilityClass();
    util.RunSafe(rsd1, "myMutexName1");
    util.RunSafe(rsd2, "myMutexName2");
    // implementation
    public class UtilityClass
    {
        public delegate void RunSafeDelegate();
        public void RunSafe(RunSafeDelegate runSafe, string mutexName)
        {
            const int WAIT_ONE_TIMEOUT = 30000;
            var sid = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
            var mar = new MutexAccessRule(sid, MutexRights.FullControl, AccessControlType.Allow);
            var ms  = new MutexSecurity();
            ms.AddAccessRule(mar);
            bool mutexCreated;
            using(var mutex = new Mutex(false, mutexName, out mutexCreated, ms))
            {
                var signalReceived = false;
                try
                {
                    try
                    {
                        signalReceived = mutex.WaitOne(WAIT_ONE_TIMEOUT, false);
                        if(!signalReceived)
                        {
                            throw new TimeoutException("Exclusive access timeout for mutex: " + mutexName);
                        }
                    }
                    catch(AbandonedMutexException)
                    {
                        signalReceived = true;
                    }
                    runSafe();
                }
                finally
                {
                    if(signalReceived)
                    {
                        mutex.ReleaseMutex();
                    }
                }
            }
        }
    }
