    public class RecurringTask
    {
        private bool _isRecurringTaskRunning = false;
        private readonly Action _task;
        private readonly TimeSpan _interval;
    
        public RecurringTask(Action task, TimeSpan interval)
        {
            Debug.Assert(_task != null);
            _task = task;
            _interval = interval;
        }
    
        public void Start()
        {
            if (_isRecurringTaskRunning)
            {
                // Already Running
                return;
            }
    
            _isRecurringTaskRunning = true;
            Device.StartTimer(_interval, () =>
            {
                if (_isRecurringTaskRunning)
                {
                    _task();
                    return true;
                }
    
                // No longer need to recur. Stop
                return false;
            });
        }
    
        public void Stop()
        {
            _isRecurringTaskRunning = false;
        }
    }
