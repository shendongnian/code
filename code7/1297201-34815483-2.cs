    public class BasicBackgroundWorker
    {
        private readonly Thread _backgroundWorkThread;
        private readonly Queue<Action> _queue = new Queue<Action>();
        private readonly ManualResetEvent _workAvailable = new ManualResetEvent(false);
        public BasicBackgroundWorker()
        {
            _backgroundWorkThread = new Thread(BackgroundThread)
            {
                IsBackground = true,
                Priority = ThreadPriority.BelowNormal,
                Name = "BasicBackgroundWorker Thread"
            };
            _backgroundWorkThread.Start();
        }
        public void EnqueueWork(Action work)
        {
            lock (_queue)
            {
                _queue.Enqueue(work);
                _workAvailable.Set();
            }
        }
        private void BackgroundThread()
        {
            while (true)
            {
                _workAvailable.WaitOne();
                Action workItem;
                lock (_queue)
                {
                    workItem = _queue.Dequeue();
                    if (_queue.Count == 0)
                    {
                        _workAvailable.Reset();
                    }
                }
                try
                {
                    workItem();
                }
                catch (Exception ex)
                {
                    //Log exception that happened in backgroundWork
                }
            }
        }
    }
