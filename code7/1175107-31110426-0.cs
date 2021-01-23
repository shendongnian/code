    public class Timer
    {
    
            private int _waitTime;
            public int WaitTime
            {
                get { return _waitTime; }
                set { _waitTime = value; }
            }
    
            private bool _isRunning;
            public bool IsRunning
            {
                get { return _isRunning; }
                set { _isRunning = value; }
            }
    
            public event EventHandler Elapsed;
            protected virtual void OnTimerElapsed()
            {
                if (Elapsed != null)
                {
                    Elapsed(this, new EventArgs());
                }
            }
    
            public Timer(int waitTime)
            {
                WaitTime = waitTime;
            }
    
            public async Task Start()
            {
                int seconds = 0;
                IsRunning = true;
                while (IsRunning)
                {
                    if (seconds != 0 && seconds % WaitTime == 0)
                    {
                        OnTimerElapsed();
                    }
                    await Task.Delay(1000);
                    seconds++;
                }
            }
    
            public void Stop()
            {
                IsRunning = false;
            }
    }
