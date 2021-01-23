    class Example
    {
        private static readonly TimeSpan MinInterval = TimeSpan.FromSeconds(3);
        private readonly Stopwatch stopwatch = new Stopwatch(); // Stopped initially
        public void MyFunction()
        {
            if (stopwatch.IsRunning && stopwatch.Elapsed < MinInterval)
            {
                return;
            }
            try
            {
                // Do stuff here.
            }
            finally
            {
                stopwatch.Restart();
            }
        }
    }
