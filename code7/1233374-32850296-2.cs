    /// <summary>
        /// Indicate if the task is running
        /// </summary>
        private volatile bool _TaskIsRunning;
        /// <summary>
        /// Indicate if the task is running
        /// </summary>
        public bool TaskIsRunning
        {
            get { return _TaskIsRunning; }
            set { _TaskIsRunning = value; }
        }
    public ClassConstructor()
    {
    TimerGetAndSendContent = new System.Timers.Timer();                
                TimerGetAndSendContent.Elapsed += Elapsed;
                TimerGetAndSendContent.Interval = Math.Ceiling(TsContent.TotalMilliseconds);
                TimerGetAndSendContent.Start();
    }
    public void Elapsed(Object sender, System.Timers.ElapsedEventArgs e))
    {
    if (!TaskIsRunning)
    {
    try
    {
    TaskIsRunning=true;
    
    //Your code
    }
    finally
    {
    TaskIsRunning=false;
    }
    }
    }
