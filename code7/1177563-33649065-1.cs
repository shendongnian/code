        public class DelayedSingleAction<T>
    {
        private readonly Func<T, int> actionOnObj;
        private T tInstance;
        private readonly long millisecondsDelay;
        private long _syncValue = 1;
        public DelayedSingleAction(Func<T, int> ActionOnObj, T TInstance, long MillisecondsDelay)
        {
            actionOnObj = ActionOnObj;
            tInstance = TInstance;
            millisecondsDelay = MillisecondsDelay;
        }
        private Task _waitingTask = null;
        private void DoActionAndClearTask(Task _)
        {
            Console.WriteLine(string.Format("{0:h:mm:ss.fff} DelayedSingleAction Resetting SyncObject: Thread {1} for {2}", DateTime.Now, System.Threading.Thread.CurrentThread.ManagedThreadId, tInstance));
            Interlocked.Exchange(ref _syncValue, 1);
            actionOnObj(tInstance);
        }
        public void PerformAction()
        {
            if (Interlocked.Exchange(ref _syncValue, 0) == 1)
            {
                Console.WriteLine(string.Format("{0:h:mm:ss.fff} DelayedSingleAction Starting the timer: Thread {1} for {2}", DateTime.Now, System.Threading.Thread.CurrentThread.ManagedThreadId, tInstance));
                _waitingTask = Task.Delay(TimeSpan.FromMilliseconds(millisecondsDelay)).ContinueWith(DoActionAndClearTask);
            }
        }
        public Task Complete()
        {
            return _waitingTask ?? Task.FromResult(0);
        }
    }
