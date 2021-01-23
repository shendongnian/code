    public class Something
    {
        public Task _myMethodTask;
        public CancellationTokenSource _cancelToken;
        public Timer _myTimer;
        public Random _rnd;
        public void Start()
        {
            _rnd = new Random((int)DateTime.Now.Ticks);
            _myTimer = new Timer(TimerElapsedHandler);
            _myTimer.Change(25, 25);
        }
        public void TimerElapsedHandler(object state)
        {
            if (!_myMethodTask.IsCompleted)
            {                
                //The current task is taking too long
                _cancelToken.Cancel();
            }
            _cancelToken = new CancellationTokenSource(TimeSpan.FromMilliseconds(25));
            _myMethodTask = new Task(() => MyMethod(), _cancelToken.Token);
        }
        public void MyMethod()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int delayTimeMs = _rnd.Next(5, 50);
            while (sw.ElapsedMilliseconds < delayTimeMs)
            {
                try
                {
                    _cancelToken.Token.ThrowIfCancellationRequested();
                    Thread.Sleep(1);
                }
                catch (TaskCanceledException)
                {
                    return;
                }
            }
        }
    }
