    private bool _isRecurringTaskRunning = false;
    private readonly Action _task;
    private readonly TimeSpan _interval;
    public bool IsRecurring { get; set; }
    public RecurringTask(Action task, TimeSpan interval, 
      bool isRecurring = true, bool start = false)
    {       
      Debug.Assert(task != null);
      _task = task;
      _interval = interval;
      IsRecurring = IsRecurring;
      if (start)
        Start();
    }
    public void Restart()
    {
      _isRecurringTaskRunning = false;
      Start();
    }
    public void Start()
    {
      if (_isRecurringTaskRunning)
        // Already Running
        return;
      _isRecurringTaskRunning = true;
      Device.StartTimer(_interval, () =>
      {
        if (_isRecurringTaskRunning)
        {
          _task();
          if (IsRecurring)
            return true;
        }
        // No longer need to recur. Stop
        return false;
      });
    }
    public void Stop() =>
      _isRecurringTaskRunning = false;
  }
