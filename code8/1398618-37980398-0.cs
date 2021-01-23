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
            var mutex = new Mutex(false, mutexName);
            mutex.WaitOne();
            runSafe();
            mutex.ReleaseMutex();
        }
    }
