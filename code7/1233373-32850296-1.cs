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
    public void Elapsed()
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
