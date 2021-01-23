    public class SimpleTimer
    {
        private DateTime StartTime;
        private DateTime LastTime;
        private bool running;
        public double ElaspedTime { get { return GetElapsedTime(); } }
        public void Start()
        {
            StartTime = DateTime.Now;
            running = true;
        }
        public void Restart()
        {
            Start();
        }
        public double GetElapsedTime()
        {
            if (!running)
                throw new Exception("SimpleTimer not running! Must call Start() prior to querying the Elapsed Time.");
            LastTime = DateTime.Now;
            var elaspedTime = LastTime - StartTime;
            return elaspedTime.TotalMilliseconds;
        }
        public double GetElapsedTimeAndRestart()
        {
            var elaspedTime = GetElapsedTime();
            Restart();
            return elaspedTime;
        }
    }
