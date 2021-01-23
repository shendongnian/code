    public class FrequencyRunner
    {
        private int _frequency;
        private Action _action;
        private bool _isStarted = false;
    
        /// <summary>
        /// частота
        /// </summary>
        public int Frequency { get { return _frequency; } set { _frequency = value; } }
    
        /// <summary>
        /// задача
        /// </summary>
        public Action Action { get { return _action; } set { _action = value; } }
    
        /// <summary>
        /// конструктор
        /// </summary>
        public FrequencyRunner()
        {
            _frequency = 1000;
            _action = () => { };
        }
    
        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="frequency"> частота </param>
        /// <param name="action"> задача </param>
        public FrequencyRunner(int frequency, Action action)
        {
            _frequency = frequency;
            _action = action;
        }
    
        /// <summary>
        /// запустить процесс
        /// </summary>
        public void Start()
        {
            _isStarted = true;
            Task.Run(() =>
            {
                Stopwatch sw = new Stopwatch();
                double interval = 1000 / _frequency;
    
                while (_isStarted)
                {
                    sw.Restart();
                    _action();
                    sw.Stop();
    
                    double timeLeft = sw.ElapsedMilliseconds;
                    if (timeLeft < interval)
                    {
                        // need wait some time...
                        sw.Restart();
                        timeLeft = interval - timeLeft;
                        while (sw.ElapsedMilliseconds < timeLeft)
                        {
                            // nothing to do
                        }
                        sw.Stop();
                    }
                }
            });
        }
    
        /// <summary>
        /// завершить процесс
        /// </summary>
        public void Stop()
        {
            _isStarted = false;
        }
    }
