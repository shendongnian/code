    public class MutableTaskWaiter
    {
        private List<Task> _tasks = new List<Task>();
        private CancellationTokenSource _cts;
        public IEnumerable<Task> Tasks
        {
            get
            {
                lock (_tasks)
                {
                    return _tasks.ToArray();
                }
            }
        }
        public void WaitAll(IEnumerable<Task> tasks)
        {
            WaitMoreTasks(tasks);
            do
            {
                try
                {
                    _cts = new CancellationTokenSource();
                    Task.WaitAll(_tasks.ToArray(), _cts.Token);
                }
                catch (OperationCanceledException)
                {
                    // start over and wait for new tasks
                }
            }
            while (_cts.IsCancellationRequested);
        }
        public void WaitAny(IEnumerable<Task> tasks)
        {
            WaitMoreTasks(tasks);
            do
            {
                try
                {
                    _cts = new CancellationTokenSource();
                    Task.WaitAny(_tasks.ToArray(), _cts.Token);
                }
                catch (OperationCanceledException)
                {
                    // start over and wait for new tasks
                }
            }
            while (_cts.IsCancellationRequested);
        }
        public void WaitMoreTasks(IEnumerable<Task> tasks)
        {
            lock (_tasks)
            {
                _tasks.AddRange(tasks);
                if (_cts != null)
                {
                    // signal the wait to restart with the updated task list
                    _cts.Cancel();
                }
            }
        }
    }
